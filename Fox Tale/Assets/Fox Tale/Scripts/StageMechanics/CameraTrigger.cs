using UnityEngine;
using static AreaTransition;

public class CameraTrigger : MonoBehaviour
{
    [Header("Change Global Light other than normal (1)")]
    public bool isLightChanger;
    public float intensity;
    [Header("Set Camera Orientation")]
    public Orientation orientation;

    private bool checkTransition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            checkTransition = changeDirection(orientation);
            if (checkTransition)
            {
                changeDirection(orientation);
                CameraController.instance.skipToPlayer();
                LevelManagerController.instance.areaTransition();
                if (isLightChanger)
                {
                    LightController.instance.changeIntensity(intensity);
                }
                else
                {
                    LightController.instance.changeIntensity(1);
                }
            }
        }
    }


    

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
         Vector3 transitionSize = new Vector3(0.4f, 4.1f, 0f);
         Vector3 center = new Vector3(-0.18f, 0.29f, 0f);
         Gizmos.color = Color.green;
         Gizmos.DrawCube(transform.position + center, transitionSize);
    }
#endif
}
