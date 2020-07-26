using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageAmount;
    private bool playerDetected;

    void Update()
    {
        if (playerDetected)
        {
            if (PlayerHealthController.instance.currentHealth > 0)
            {
                PlayerHealthController.instance.dealDamage(damageAmount);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
        }
    }
}
