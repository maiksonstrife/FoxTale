using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankHitBox : MonoBehaviour
{
    public BossTankController bossController;

    //this hitbox is only active until hit
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerController.instance.transform.position.y > transform.position.y) //only if player is coming from above
        {
            bossController.takeHit();
            PlayerController.instance.bumpbounce();
            CameraShakeController.instance.startShake(.1f, .5f);
            gameObject.SetActive(false);
        }
    }
}
