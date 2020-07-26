using UnityEngine;

public class BossAreaTrigger : MonoBehaviour
{
    public GameObject theBoss;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            theBoss.SetActive(true);
            AudioManager.instance.playBossMusic();
        }
    }
}
