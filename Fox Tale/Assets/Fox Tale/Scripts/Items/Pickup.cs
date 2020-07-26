using UnityEngine;

public class Pickup : MonoBehaviour
{

    public bool isGem;
    public bool isHeal;
    public int healAmount;
    public GameObject pickupEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isGem)
            {
                LevelManagerController.instance.gemscollected++;
                Destroy(gameObject);
                Instantiate(pickupEffect, transform.position, transform.rotation);
                UIController.instance.updateGemDisplay();
                AudioManager.instance.playSFX(6);
            }

            if (isHeal)
            {
                if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.healPlayer(healAmount);
                    Destroy(gameObject);
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                    AudioManager.instance.playSFX(7);
                }
            }
        }
    }
}
