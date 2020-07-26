using System.Collections;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    private SpriteRenderer theSR;
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    public void fadeOut()
    {
        StartCoroutine(fadeOutCo());
    }

    public void fadeIn()
    {
        StartCoroutine(fadeInCo());
    }

    IEnumerator fadeOutCo()
    {
        float counter = 0;
        //Get current color
        Color spriteColor = theSR.material.color;

        while (counter < 1)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(1, 0, counter / 1);
            Debug.Log(alpha);

            //Change alpha only
            theSR.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            //Wait for a frame
            yield return null;
        }
    }

    IEnumerator fadeInCo()
    {
        float counter = 0;
        //Get current color
        Color spriteColor = theSR.material.color;

        while (counter < 1)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(0, 1, counter / 1);
            Debug.Log(alpha);

            //Change alpha only
            theSR.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            //Wait for a frame
            yield return null;
        }
    }
}
