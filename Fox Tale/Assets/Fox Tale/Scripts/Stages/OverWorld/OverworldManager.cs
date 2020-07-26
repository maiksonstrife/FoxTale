using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldManager : MonoBehaviour
{
    public static OverworldManager instance;
    private MapPoint[] allPoints;
    public PlayerOverWorld thePlayer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        allPoints = FindObjectsOfType<MapPoint>();

        if (PlayerPrefs.HasKey("Curent Level_"))
        {
            foreach (MapPoint point in allPoints)
            {
                if (point.levelToLoad == PlayerPrefs.GetString("Curent Level_"))
                {
                    thePlayer.transform.position = point.transform.position;
                    thePlayer.currentPoint = point;
                }
            }
        }
    }

    public void LoadLevel(string levelToLoad)
    {
        StartCoroutine(loadLevelCoroutine(levelToLoad));
    }

    public IEnumerator loadLevelCoroutine(string levelToLoad)
    {
        OverworldUIController.instance.fadeScreenToBlack();
        yield return new WaitForSeconds((1f / OverworldUIController.instance.fadeSpeed) + .25f);
        SceneManager.LoadScene(levelToLoad);
    }
}
