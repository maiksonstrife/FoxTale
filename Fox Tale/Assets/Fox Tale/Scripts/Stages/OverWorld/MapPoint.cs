using UnityEngine;
using UnityEngine.UI;

public class MapPoint : MonoBehaviour
{
    [Header("Get MapPoints Around Current Position")]
    public MapPoint up;
    public MapPoint right;
    public MapPoint down;
    public MapPoint left;
    public GameObject gemBadge, clockBadge;
    public bool isLevel, isLocked;
    public string levelToLoad, levelToCheck, levelName;
    public int gemsCollected, totalGems;
    public float bestTime, timeAttackTime;


    // Start is called before the first frame update
    void Start()
    {
        CheckStageUnlock();
    }

    //check if the previous stage was completed
    public void CheckStageUnlock()
    {
        if (isLevel && levelToLoad != null)
        {
            //level defaultState
            isLocked = true;

            //load Level Statistics
            if (PlayerPrefs.HasKey(levelToLoad + "_gems")) //if gems save exists
            {
                gemsCollected = PlayerPrefs.GetInt(levelToLoad + "_gems"); //get gems save info
            }

            if (PlayerPrefs.HasKey(levelToLoad + "_time"))
            {
                bestTime = PlayerPrefs.GetFloat(levelToLoad + "_time");
            }

            //isCompleted?
            if(gemsCollected >= totalGems)
            {
                gemBadge.SetActive(true);
            }
            if (bestTime <= timeAttackTime && bestTime != 0)
            {
                clockBadge.SetActive(true);
            }

            //islevel unlocked?
            if (levelToCheck != null)
            {
                if (PlayerPrefs.HasKey(levelToCheck + "_cleared"))
                {
                    if (PlayerPrefs.GetInt(levelToCheck + "_cleared") == 1)
                    {
                        isLocked = false;
                    }
                }
            }
        }

        //that's for level 1-1 to always be unlocked
        if (levelToLoad == levelToCheck)
        {
            isLocked = false;
        }
    }
}
