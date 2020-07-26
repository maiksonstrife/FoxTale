using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AreaNaming : MonoBehaviour
{
    public Vector3 labelLocation;
    public string areaName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Color guiColor = new Color(0.5f, .5f, .5f, 0.8f);
        Texture2D texture = new Texture2D(1, 1);
        GUIStyle style = new GUIStyle(GUI.skin.box);
        style.normal.background = texture;
        texture.SetPixel(1, 1, guiColor);
        texture.Apply();
        style.fontSize = 15;
        style.normal.textColor = Color.white;
        Handles.Label(transform.position + labelLocation, areaName, style);
    }
#endif
}
