using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public int damageAmount;

    private void Start()
    {
        AudioManager.instance.playSFX(2);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(-speed * transform.localScale.x * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthController.instance.dealDamage(damageAmount);
            AudioManager.instance.playSFX(1);
        }
        Destroy(gameObject);
    }
}

