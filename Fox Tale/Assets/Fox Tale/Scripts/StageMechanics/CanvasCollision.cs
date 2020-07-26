using UnityEngine;

public class CanvasCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CameraController.instance.updateCanvas(true);
        }
    }
}
