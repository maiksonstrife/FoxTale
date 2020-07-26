using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldCameraController : MonoBehaviour
{
    public Transform target;

    [Header("Default Camera (upper right)")]
    public float max_X;
    public float max_Y;
    [Header("Default Camera (lower left)")]
    public float min_X;
    public float min_Y;

    private void Awake()
    {
        Application.targetFrameRate = 30;
        Screen.SetResolution(1920, 1080, true);
    }

    private void LateUpdate()
    {
        CameraFollow();
    }

    void CameraFollow()
    {
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, min_X, max_X),
            Mathf.Clamp(target.position.y - 1, min_Y, max_Y),
            transform.position.z
            );
    }
}
