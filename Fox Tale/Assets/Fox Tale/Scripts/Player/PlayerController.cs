using UnityEngine;
using Pixeye.Unity;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float velocityY;

    [Foldout("Knockback")]
    public float knobackForce, knockbackCounter, knockbackLenght;

    [Foldout("Movement", true)]
    public float moveSpeed;
    public float jumpForce;
    public float bumpForce;
    public bool hasDoubleJump;
    public float timerGhostJump;
    public float resetTimerGhostJump;
    public bool isGrounded;
    public bool isSwimming;
    public bool isFreezed;

    [Foldout("Get Components", true)]
    public Rigidbody2D theRb;
    public BoxCollider2D playerCollider;
    public Transform checkGround;
    public LayerMask whatIsGround;
    public LayerMask WhatIsWater;
    public SpriteRenderer theSR;
    public ParticleSystem footDust;
    public ParticleSystem impactDust;
    private ParticleSystem.EmissionModule footEmission; //the emission component within particle system to be acessed from script

    private Animator anim;
    [Foldout("Get Components", false)]

    //Update
    private bool isJump;
    private bool isDoubleJump;

    // FixedUpdate
    private bool doMove;
    private bool doJump;
    private bool doDoubleJump;
    private bool doKnockback;
    private bool doBump;
    public bool doFlip;
    private bool wasOnGround;

    //trying new camera
    public Transform camTarget;
    public float aheadAmount, aheadSpeed;

    #region XBOX GUIDE
    /* Jump = Y
     * Fire 2 = B
     * Fire 1 = A
     * Fire 3 = X
     * Jump = Y
     * 
     * 
     * */

    #endregion


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
        footEmission = footDust.emission;
        timerGhostJump = 0;
        resetTimerGhostJump = 0.18f;
    }

    // Update is called once per frame
    void Update()
    {
        velocityY = theRb.velocity.y;
        if (!PauseMenu.instance.isPaused && !isFreezed)
        {
            playerMovement();
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(theRb.velocity.x));
        if(isSwimming == false)
        {
            anim.SetBool("isGrounded", isGrounded);
        }
        
    }

    public void playerMovement()
    {
        isGrounded = Physics2D.OverlapCircle(checkGround.transform.position, 0.2f, whatIsGround);
        isSwimming = Physics2D.OverlapCircle(checkGround.transform.position, 0.2f, WhatIsWater);

        if (knockbackCounter <= 0)
        {
            doFlip = true;
            doMove = true;

            if (isGrounded || isSwimming)
            {
                isJump = true;
                isDoubleJump = true;
                timerGhostJump = resetTimerGhostJump;
            }
            else
            {
                timerGhostJump -= Time.deltaTime;
            }
            
            if (Input.GetButtonDown("Jump"))
            {
                if (isJump && timerGhostJump > 0)
                {
                    doJump = true;
                }
                else
                {
                    if (isDoubleJump && hasDoubleJump)
                    {
                        doDoubleJump = true;
                    }
                }
            }

        }
        else
        {
            doMove = false;
            knockbackCounter -= Time.deltaTime;
        }
    }


    private void FixedUpdate()
    {
        if (doMove)
        {
            theRb.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal") , theRb.velocity.y);

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                camTarget.localPosition = new Vector3(Mathf.Lerp(camTarget.localPosition.x, aheadAmount * Input.GetAxisRaw("Horizontal"), aheadSpeed * Time.deltaTime), camTarget.localPosition.y, camTarget.localPosition.z);
            }

            //Particle System Walking
            if (Input.GetAxisRaw("Horizontal") != 0 && isGrounded)
            {
                footEmission.rateOverTime = 15f;
            }
            else
            {
                footEmission.rateOverTime = 0f;
            }

            //Particle System Jump Impact
            if(!wasOnGround && isGrounded)
            {
                impactDust.gameObject.SetActive(true);
                impactDust.Stop();
                impactDust.transform.position = footDust.transform.position;
                impactDust.Play();
            }
            wasOnGround = isGrounded;
        }

        if (doJump){
            theRb.velocity = Vector2.up * jumpForce;
            doJump = false;
            isJump = false;
            AudioManager.instance.playSFX(10);
        }

        if (doDoubleJump)
        {
            theRb.velocity = new Vector2(theRb.velocity.x, jumpForce);
            doDoubleJump = false;
            isDoubleJump = false;
            AudioManager.instance.playSFX(10);
        }

        if (doKnockback)
        {
            if (!theSR.flipX)
            {
                doMove = false;
                doFlip = false;
                theRb.velocity = new Vector2(-knobackForce, 0f);
                knockbackCounter = knockbackLenght;
                anim.SetTrigger("hit");
            }
            else
            {
                doMove = false;
                doFlip = false;
                theRb.velocity = new Vector2(knobackForce, 0f);
                knockbackCounter = knockbackLenght;
                anim.SetTrigger("hit");
            }
            doKnockback = false;
        }

        if (doBump)
        {
            theRb.velocity = new Vector2(0f, bumpForce);
            doBump = false;
            AudioManager.instance.playSFX(10);
        }


        if (doFlip)
        {
            if (theRb.velocity.x < 0 && !isFreezed)
            {
                theSR.flipX = true;
            }
            else if (theRb.velocity.x > 0 && !isFreezed)
            {
                theSR.flipX = false;
            }
        }
        

        if (isFreezed)
        {
            theRb.velocity = new Vector2(0f, theRb.velocity.y);
        }
    }

    //Player Events
    public void freezePlayer(bool doFreeze)
    {
        if (doFreeze)
        {
            isFreezed = true;
        }
        else
        {
            isFreezed = false;
        }
    }

    public void knockbackPlayer()
    {
        doKnockback = true;
    }

    public void bumpbounce()
    {
        doBump = true;
    }

    //Player Collisions
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.parent = null;
        }
    }
}
