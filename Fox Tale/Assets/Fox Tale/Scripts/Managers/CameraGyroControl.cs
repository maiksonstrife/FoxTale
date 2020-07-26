using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyroControl : MonoBehaviour
{

    private bool gyroEnabled;
    private Gyroscope gyro;
    private GameObject cameraContainer;
    private Quaternion rot;

    // Start is called before the first frame update
    void Start()
    {
        cameraContainer = new GameObject("Camera Container"); //create a new GameObject
        cameraContainer.transform.position = transform.position; //set new GameObject transform to the object attached
        transform.SetParent(cameraContainer.transform); //put the camera on this new GameObject

        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);
            return true;
        }
        return false;
    }

    private void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;
        }
    }
}
