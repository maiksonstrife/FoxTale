using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string StartScene, continueScene;
    public GameObject continueButton;

    private void Awake()
    {
        Application.targetFrameRate = 30;
        Screen.SetResolution(1920, 1080, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(StartScene + "_cleared"))
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void continueGame()
    {
        SceneManager.LoadScene(continueScene);
    }

    public void startGame()
    {
        SceneManager.LoadScene(StartScene);
        PlayerPrefs.DeleteAll();
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }
}
