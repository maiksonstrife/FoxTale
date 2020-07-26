using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth, maxHealth;
    public float cooldownDamageLenght, cooldownDamageTimer;
    public bool isDead;
    public bool isInvincible;
    public SpriteRenderer theSR;
    public GameObject deathEffect;
    private Color defaultColor;
    private Drop drop;
    private Material matWhite;
    private Material matDefault;


    // Start is called before the first frame update
    void Start()
    {
        drop = GetComponent<Drop>();
        currentHealth = maxHealth;
        defaultColor = theSR.color;
        matDefault = theSR.material;
        matWhite = Resources.Load("Materials/WhiteFlash", typeof(Material)) as Material;

    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownDamageTimer > 0)
        {
            cooldownDamageTimer -= Time.deltaTime;
            //returning to normal state
            if (cooldownDamageTimer <= 0)
            {
                theSR.color = defaultColor;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }

        if (isDead == true)
        {
            currentHealth = 0;
            //CameraShakeController.instance.startShake(.1f, .1f);
            Instantiate(deathEffect, theSR.transform.position, theSR.transform.rotation);
            drop.itemDrop();
            gameObject.SetActive(false);
            AudioManager.instance.playSFX(3);
        }

        if (isInvincible)
        {
            currentHealth = maxHealth;
        }
    }

    public void dealDamage(int amountDamage)
    {
        if (cooldownDamageTimer <= 0)
        {
            CameraShakeController.instance.startShake(.1f, .1f);

            currentHealth -= amountDamage;
            if (currentHealth <= 0)
            {
                isDead = true;
            }
            else
            {
                theSR.color = new Color(1, 1, 1, 1f);
                theSR.material = matWhite;
                Invoke("resetMaterial", .10f);
                Invoke("cooldownStart", .10f);
            }
        }
    }

    private void resetMaterial()
    {
        theSR.material = matDefault;
    }

    private void cooldownStart()
    {
        cooldownDamageTimer = cooldownDamageLenght;
        theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);
    }
}
