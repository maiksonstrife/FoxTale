using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeController : MonoBehaviour
{
    public static CameraShakeController instance;

    private float shakeTimer, shakePower;
    private float shakeFadetime;
    private float shakeRotation;
    public float rotationMultiplier = 15f;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        //debug 
        if (Input.GetKeyDown(KeyCode.J))
        {
            startShake(.5f, 1f);
        }
    }

    private void LateUpdate()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;

            float xAmount = Random.Range(-1, 1) * shakePower;
            float yAmount = Random.Range(-1, 1) * shakePower;
            transform.position += new Vector3(xAmount, yAmount, 0f);
            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadetime * Time.deltaTime);
            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadetime * rotationMultiplier * Time.deltaTime);
        }
        transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1, 1));
    }

    public void startShake(float lenght, float power)
    {
        shakeTimer = lenght;
        shakePower = power;
        shakeFadetime = power / lenght;
        shakeRotation = power * rotationMultiplier;
    }
}
