using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingWhiteEffect : MonoBehaviour
{
    public float timeLeft;
    public Material targetColor;
    public Material defaultColor;
    public SpriteRenderer sr;

    private Material material;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        targetColor = Resources.Load("Materials/WhiteFlash", typeof(Material)) as Material;
        defaultColor = sr.material;
        timeLeft = 2.0f;
    }

    void Update()
    {
        if (timeLeft <= Time.deltaTime)
        {
            StartCoroutine("flashCoroutine");
            timeLeft = 1.0f;
        }
        else
        {
            // transition in progress
            // sr.material = defaultColor;
            // update the timer
            timeLeft -= Time.deltaTime;
        }
    }

    IEnumerator flashCoroutine()
    {

        sr.material = defaultColor;
        //Normal Color for 1sec
        yield return new WaitForSeconds(.25f);
        //Blinking Effect
        sr.material = targetColor;
        yield return new WaitForSeconds(.25f);
        sr.material = defaultColor;
    }
}
