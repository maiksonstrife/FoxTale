using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public static TextBoxManager instance;

    public GameObject textBox;
    public Text textInBox;
    public TextAsset textFile;
    public string[] textLines;

    public bool isTyping;
    public bool cancelTyping;
    public float typeSpeed;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
    }

    public void enableTextBox(int start, int end)
    {

        if (end == 0)
        {
            end = textLines.Length - 1;
        }

        if (start <= end)
        {
            StartCoroutine(textScroolCoroutine(textLines[start]));
        }
        else if (start > end)
        {
            disableTextBox();
        }

        textBox.SetActive(true);
        textLines = (textFile.text.Split('\n'));
    }

    public void disableTextBox()
    {
        textBox.SetActive(false);
    }

    public void UpdateCoroutine(int start)
    {
        if (start > textLines.Length - 1)
        {
            start = start - 1;
        } 
        StartCoroutine(textScroolCoroutine(textLines[start]));
    }

    private IEnumerator textScroolCoroutine(string lineOfText)
    {
        int letter = 0;
        textInBox.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            textInBox.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        textInBox.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

}
