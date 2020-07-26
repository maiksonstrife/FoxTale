using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextActivate : MonoBehaviour
{
    public GameObject directionalup;
    public int startLine;
    public int endAtLine;
    public int start;
    private bool isTalk;
    private bool stopAxisInput;
    private bool isInstantiated;
    public bool hasTalked;


    // Start is called before the first frame update
    void Start()
    {
        start = startLine;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTalk == true)
        {

            if (startLine > endAtLine)
            {
                TextBoxManager.instance.disableTextBox();
                directionalup.SetActive(false);
                isTalk = false;
                isInstantiated = false;
                startLine = start;
                PlayerController.instance.freezePlayer(false);
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                hasTalked = true;
                PlayerController.instance.freezePlayer(true);
                    
                    //Instancia apenas uma vez
                    if (!isInstantiated)
                    {
                        TextBoxManager.instance.enableTextBox(startLine, endAtLine);
                        isInstantiated = true;
                    }
                    //uma vez instanciado entrar em Loop de troca de linhas
                    else if (!TextBoxManager.instance.isTyping)
                    {
                        TextBoxManager.instance.UpdateCoroutine(startLine += 1);
                    }
                    else if (TextBoxManager.instance.isTyping && !TextBoxManager.instance.cancelTyping)
                    {
                        TextBoxManager.instance.cancelTyping = true;
                    }
            }
        }     
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            directionalup.SetActive(true);
            isTalk = true;
            isInstantiated = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            directionalup.SetActive(false);
            isTalk = false;
            TextBoxManager.instance.disableTextBox();
            startLine = start;
        }
    }
}
