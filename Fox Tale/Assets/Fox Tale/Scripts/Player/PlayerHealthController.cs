using UnityEngine;
using Pixeye.Unity;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    [Foldout("Get Components")]
    public GameObject deathEffect;
    private SpriteRenderer sprite;

    [Foldout("HEALTH", true)]
    public int currentHealth, maxHealth;
    public float cooldownDamageLenght, cooldownDamageTimer;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownDamageTimer > 0)
        {
            cooldownDamageTimer -= Time.deltaTime;

            if (cooldownDamageTimer <= 0)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
            }
        }
        
    }


    public void dealDamage(int amountDamage)
    {
        
        if (cooldownDamageTimer <= 0)
        {
            currentHealth -= amountDamage;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Instantiate(deathEffect, transform.position, transform.rotation);
                LevelManagerController.instance.respawnPlayer();
            }
            else
            {
                cooldownDamageTimer = cooldownDamageLenght;
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, .5f);
                PlayerController.instance.knockbackPlayer();
                AudioManager.instance.playSFX(9);
            }

            UIController.instance.updateHeartDisplay();
        }
    }

    public void healPlayer(int amountHeal)
    {
        currentHealth += amountHeal;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.updateHeartDisplay();
    }

}
