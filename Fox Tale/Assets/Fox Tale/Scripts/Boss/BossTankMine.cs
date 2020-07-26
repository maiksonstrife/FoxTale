using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankMine : MonoBehaviour
{
    public GameObject explosion;

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
        if( other.CompareTag("Player")){
            explodeMines();
            PlayerHealthController.instance.dealDamage(2);
        }
    }

    public void explodeMines()
    {
        Destroy(gameObject);
        AudioManager.instance.playSFX(3);
        Instantiate(explosion, transform.position, transform.rotation);
        CameraShakeController.instance.startShake(.2f, .5f);
    }
}
