using UnityEngine;

public class Twomp : MonoBehaviour
{
    public float fallVelocity;
    public float returnVelocity;
    public GameObject target;
    private bool moveDown;
    private Vector3 returnPoint;

    // Start is called before the first frame update
    void Start()
    {
        returnPoint = new Vector3 (transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, fallVelocity * Time.deltaTime);
        }
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, returnPoint, returnVelocity * Time.deltaTime);
        }
      

        if(Vector3.Distance(transform.position, target.transform.position) < .1f )
        {
            moveDown = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Vector3.Distance(transform.position, returnPoint) < .1f)
            {
                moveDown = true;
            }
            
        }
    }
}
