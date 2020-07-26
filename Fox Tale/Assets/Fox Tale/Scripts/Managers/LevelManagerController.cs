using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerController : MonoBehaviour
{
    public static LevelManagerController instance;

    public float waitToRespawn;
    public int gemscollected;
    public string nextLevel;
    public float timeInLevel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timeInLevel = 0;
    }

    private void Update()
    {
        timeInLevel += Time.deltaTime;
    }


    public void respawnPlayer()
    {
        StartCoroutine(spawnCoroutine());
    }

    public IEnumerator spawnCoroutine()
    {
        //Desativando
        PlayerController.instance.gameObject.SetActive(false);
        AudioManager.instance.playSFX(8);
        yield return new WaitForSeconds(waitToRespawn - 1f / UIController.instance.fadeSpeed); //add buffer to respawn player 
        UIController.instance.fadeScreenToBlack();
        yield return new WaitForSeconds((waitToRespawn - 1f / UIController.instance.fadeSpeedFromBlack) + .2f);
        UIController.instance.fadeScreenFromBlack();

        //Ativando
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        UIController.instance.updateHeartDisplay();
        LightController.instance.loadIntensity();
        CameraController.instance.loadDefault();
    }

    public void endLevel()
    {
        StartCoroutine(endLevelCoroutine());
    }

    public IEnumerator endLevelCoroutine()
    {
        AudioManager.instance.playVictory();
        PlayerController.instance.freezePlayer(true);
        CameraController.instance.isStopFollow = true;
        UIController.instance.levelCompletedText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIController.instance.fadeScreenToBlack();
        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeedFromBlack) + 3f); //3f stands for level end music
        ProgressManager.instance.saveGame(gemscollected, timeInLevel);
        SceneManager.LoadScene(nextLevel);
    }

    public void areaTransition()
    {
        StartCoroutine(areaTransitionCo());
    }

    public IEnumerator areaTransitionCo()
    {
        UIController.instance.fadeToBlackInstantly();
        yield return new WaitForSeconds(0.15f);
        UIController.instance.fadeScreenFromBlack();
    }
}
