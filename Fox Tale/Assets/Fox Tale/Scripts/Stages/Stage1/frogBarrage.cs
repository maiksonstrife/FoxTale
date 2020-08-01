using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogBarrage : MonoBehaviour
{
    public GameObject directionalup;
    public SpriteRenderer frogArouse;
    public BoxCollider2D barrage;
    public int startLine;
    public int endAtLine;
    private int start;
    public bool isTalk;
    private bool stopAxisInput;
    public bool isInstantiated;
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

                if (FirstStage_FrogHouse.instance.barrageOpened)
                {
                    frogArouse.color = new Color(1f, 0.5f, 1f, 3);
                    barrage.isTrigger = true;
                }
                
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                hasTalked = true;
                PlayerController.instance.freezePlayer(true);

                    if (!isInstantiated)
                    {
                        TextBoxManager.instance.enableTextBox(startLine, endAtLine);
                        isInstantiated = true;
                    }

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
            if (FirstStage_FrogHouse.instance.barrageOpened)
            {
                start = 23;
                startLine = 23;
                endAtLine = 27;
            }
            directionalup.SetActive(true);
            isTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (FirstStage_FrogHouse.instance.barrageOpened)
            {
                start = 23;
                startLine = 23;
                endAtLine = 26;
            }
            directionalup.SetActive(false);
            isTalk = false;
            TextBoxManager.instance.disableTextBox();
            startLine = start;
        }
    }
}
