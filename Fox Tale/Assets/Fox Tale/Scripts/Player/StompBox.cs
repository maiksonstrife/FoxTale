using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    public GameObject deathEffect;
    public bool canStomp;

    // Start is called before the first frame update
    void Start()
    {
        canStomp = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canStomp)
        {
            if (other.CompareTag("Stomp"))
            {
                PlayerController.instance.bumpbounce();
                if (!other.GetComponentInParent<EnemyHealth>().isDead)
                {
                    other.GetComponentInParent<EnemyHealth>().dealDamage(1);
                }
            }

            if (other.CompareTag("StompNpc"))
            {
                PlayerController.instance.bumpbounce();
            }
        }
    }

}
