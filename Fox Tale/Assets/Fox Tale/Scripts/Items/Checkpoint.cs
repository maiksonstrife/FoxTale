using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite checkpointOn, checkpointOff;

    public float minX, maxX;
    public float minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            CheckpointController.instance.deactivateCheckpoints();

            sr.sprite = checkpointOn;
            CheckpointController.instance.setSpawnPoint(transform.position);

            CameraController.instance.saveDeffault();

            LightController.instance.saveIntensity();
        };
    }

    public void resetCheckpoints()
    {
        sr.sprite = checkpointOff;
    }

}
