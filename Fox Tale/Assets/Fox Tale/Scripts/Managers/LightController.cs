using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class LightController : MonoBehaviour
{
    public Light2D The2DLights;
    public static LightController instance;

    public float savedIntensity;

    private void Awake()
    {
        instance = this;
    }

    public void changeIntensity(float intensity)
    {
        The2DLights.intensity = intensity;
    }

    public void saveIntensity()
    {
        savedIntensity = The2DLights.intensity;
    }

    public void loadIntensity()
    {
        The2DLights.intensity = savedIntensity;
    }
}
