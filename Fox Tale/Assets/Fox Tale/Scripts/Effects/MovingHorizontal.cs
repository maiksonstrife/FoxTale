using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHorizontal : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
    }
}
