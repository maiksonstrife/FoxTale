using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pixeye.Unity;


public class OverworldUIController : MonoBehaviour
{
    public static OverworldUIController instance;

    public float fadeSpeed;
    private bool isFadeToBlack, isFadeFromBlack;
    [Foldout("Get Components", true)]
    public Image fadeToBlack;
    public GameObject levelInfoPanel;
    public Text levelName, gemsFound, gemsInLevel, bestTime, timeAttack;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        fadeScreenFromBlack();
    }

    void Update()
    {
        fadeScreen();
    }


    //Panel UI Info
    public void showInfo(MapPoint levelInfo)
    {
        levelName.text = levelInfo.levelName;
        gemsFound.text = "FOUND: " + levelInfo.gemsCollected;
        gemsInLevel.text = "IN LEVEL: " + levelInfo.totalGems;
        timeAttack.text = "TIME ATTACK: " + levelInfo.timeAttackTime.ToString("F2") + "s";
        if(levelInfo.bestTime == 0)
        {
            bestTime.text = "BEST: ----";
        }
        else
        {
            bestTime.text = "BEST: " + levelInfo.bestTime.ToString("F2") + "s";
        }
        levelInfoPanel.SetActive(true);
    }

    public void showInfoLocked()
    {
        levelName.text = "LOCKED, CLEAR PREVIOUS STAGE FIRST";
        gemsFound.text = "FOUND: 0";
        gemsInLevel.text = "IN LEVEL: 0";
        timeAttack.text = "TIME ATTACK: --:--'s";
        levelInfoPanel.SetActive(true);
    }



    public void hideInfo()
    {
        levelInfoPanel.SetActive(false);
    }

    //Fade Screen
    private void fadeScreen()
    {
        if (isFadeToBlack)
        {
            fadeToBlack.color = new Color(fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, Mathf.MoveTowards(fadeToBlack.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeToBlack.color.a == 1f)
            {
                isFadeToBlack = false;
            }
        }

        if (isFadeFromBlack)
        {
            fadeToBlack.color = new Color(fadeToBlack.color.r, fadeToBlack.color.g, fadeToBlack.color.b, Mathf.MoveTowards(fadeToBlack.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeToBlack.color.a == 0f)
            {
                isFadeFromBlack = false;
            }
        }
    }

    public void fadeScreenToBlack()
    {
        isFadeToBlack = true;
        isFadeFromBlack = false;
    }

    public void fadeScreenFromBlack()
    {
        isFadeToBlack = false;
        isFadeFromBlack = true;
    }
}
