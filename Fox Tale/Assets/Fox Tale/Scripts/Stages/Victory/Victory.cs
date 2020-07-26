using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public string mainMenu;

    private void Awake()
    {
        Application.targetFrameRate = 30;
        Screen.SetResolution(1920, 1080, true);
    }

    public void toMenuScreen()
    {
        SceneManager.LoadScene(mainMenu);
    }

}
