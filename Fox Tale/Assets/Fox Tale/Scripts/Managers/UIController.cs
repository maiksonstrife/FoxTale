using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Image heart1, heart2, heart3; //UI Image Propriety
    public Sprite fullHeart, emptyHeart, halfHeart; //Sprite itself
    public Text gemsText;
    public GameObject levelCompletedText;

    public Image fadeToBlack;
    public float fadeSpeed, fadeSpeedFromBlack;
    public bool isFadeToBlack, isFadeFromBlack, isFadeToBlackInstantly;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        updateGemDisplay();
        fadeScreenFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeToBlack)
        {
            fadeToBlack.color = new Color(fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, Mathf.MoveTowards(fadeToBlack.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(fadeToBlack.color.a == 1f)
            {
                isFadeToBlack = false;
            }
        }

        if (isFadeFromBlack)
        {
            fadeToBlack.color = new Color(fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, Mathf.MoveTowards(fadeToBlack.color.a, 0f, fadeSpeedFromBlack * Time.deltaTime));
            if (fadeToBlack.color.a == 0f)
            {
                isFadeFromBlack = false;
            }
        }

        if (isFadeToBlackInstantly)
        {
            fadeToBlack.color = new Color(fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, 1f);
            if (fadeToBlack.color.a == 0f)
            {
                isFadeToBlackInstantly = false;
            }
        }

    }

    public void updateHeartDisplay()
    {
        switch(PlayerHealthController.instance.currentHealth)
        {
            case 6:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
                break;
            case 5:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = halfHeart;
                break;
            case 4:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = emptyHeart;
                break;
            case 3 :
                heart1.sprite = fullHeart;
                heart2.sprite = halfHeart;
                heart3.sprite = emptyHeart;
                break;
            case 2 :
                heart1.sprite = fullHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;
            case 1:
                heart1.sprite = halfHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;
            case 0:
                heart1.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;
                break;

        }
    }

    public void updateGemDisplay()
    {
        gemsText.text = LevelManagerController.instance.gemscollected.ToString();
    }

    public void fadeScreenToBlack()
    {
        isFadeToBlack = true;
        isFadeFromBlack = false;
        isFadeToBlackInstantly = false;
    }

    public void fadeScreenFromBlack()
    {
        isFadeToBlack = false;
        isFadeFromBlack = true;
        isFadeToBlackInstantly = false;
    }

    public void fadeToBlackInstantly()
    {
        isFadeToBlack = false;
        isFadeFromBlack = false;
        isFadeToBlackInstantly = true;
    }
}
