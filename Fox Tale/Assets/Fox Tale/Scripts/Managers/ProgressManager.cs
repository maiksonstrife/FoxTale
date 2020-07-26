using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void saveGame(int gemsCollected, float timeInLevel)
    {
        //SAVING GEMS
        //If key exist, check if better than previous, if so, save.
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gems"))
        {
            if(gemsCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_gems"))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected);
            }
        }
        //Id key doesn't exist, save.
        else
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected);
        }

        //SAVING BEST TIME
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if (timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time"))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
        }

        //SAVING STAGE PROGRESS
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_cleared", 1);
        PlayerPrefs.SetString("Curent Level_", SceneManager.GetActiveScene().name);
    }
}
