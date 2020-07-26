using UnityEngine;
using Pixeye.Unity;


public class JumpGravity : MonoBehaviour
{
    [Foldout("Get Components")]
    public Rigidbody2D theRb;

    [Foldout("JumpGravity", true)]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    bool playerGravityOff;


    private void Awake()
    {
        theRb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (theRb.velocity.y < 0)
        {
            theRb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (theRb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            theRb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
            theRb.velocity = new Vector2(theRb.velocity.x, Mathf.Clamp(theRb.velocity.y, -22, +30)); //min //max
    }

}
