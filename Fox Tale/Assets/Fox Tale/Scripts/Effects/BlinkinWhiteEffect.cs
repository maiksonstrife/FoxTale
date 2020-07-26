using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkinWhiteEffect : MonoBehaviour
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
            timeLeft -= Time.deltaTime;
        }
    }

    IEnumerator flashCoroutine()
    {

        sr.material = defaultColor;
        yield return new  WaitForSeconds(.25f);
        sr.material = targetColor;
        yield return new WaitForSeconds(.25f);
        sr.material = defaultColor;
    }

    void ResetMaterial()
    {
        sr.material = defaultColor;
    }
}
