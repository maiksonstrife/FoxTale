using UnityEngine;
using Pixeye.Unity;


public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    //[Header("Camera Boundaries")]
    //[SerializeField]
    //private float leftLimit, rightLimit, bottomLimit, topLimit;
    [Header("Default Camera Limit (upper right)")]
    public float max_X; 
    public float max_Y;
    [Header("Default Camera Limit (lower left)")]
    public float min_X;
    public float min_Y;
    [Header("Camera Adjustments")]
    public float cameraSpeed;
    //public float moveAhead;
    [Header("Parallax Adjustments")]
    public float cameraSpeedParallax;

    private float defaultMax_X;
    private float defaultMax_Y;
    private float defaultMin_X;
    private float defaultMin_Y;

    public bool isStopFollow;
    private bool isSkipToPlayer;
    public float cameraSpeedFall;
    public bool updateCanvasY;

    [Foldout("Get Components", true)]
    public Transform target;
    public Transform farBackground, middleBackGround;
    public Rigidbody2D theRb;
    private Vector2 amountMoveCanvas;

    public float playerVelocity;

    private void Awake()
    {
        skipToPlayer();
        instance = this;
        cameraSpeedParallax = 10;
        Application.targetFrameRate = 30;
        Screen.SetResolution(1920, 1080, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        defaultMax_X = max_X;
        defaultMax_Y = max_Y;
        defaultMin_X = min_X;
        defaultMin_Y = min_Y;
    }

    private void FixedUpdate()
    {
        if (!isStopFollow)
        {
            if (isSkipToPlayer)
            {
                skipToPlayer();
            }
            else
            {
                if (!PlayerController.instance.isFreezed)
                {
                    parallaxEffect();
                    CameraFollowAhead();
                }
            }  
        }
    }

    void CameraFollowAhead()
    {

        if (!isSkipToPlayer)
        {
            //-22 is equal to "falling"
            if (theRb.velocity.y <= -22)
            {
                cameraSpeedFall += 0.100f * 1.5f;
                transform.position = Vector3.Lerp(transform.position, new Vector3( 
                Mathf.Clamp(target.position.x, min_X, max_X), 
                Mathf.Clamp(target.position.y + (-5f), min_Y, max_Y), 
                -10), cameraSpeedFall * Time.deltaTime
                );
            }
            else
            {
                cameraSpeedFall = 0;
            }

            //on normal
            if (!PlayerController.instance.theSR.flipX)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3( 
                Mathf.Clamp(target.position.x, min_X, max_X),
                Mathf.Clamp(target.position.y, min_Y, max_Y), 
                -10), cameraSpeed * Time.deltaTime
                );
            }
            else if (PlayerController.instance.theSR.flipX)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3( 
                Mathf.Clamp(target.position.x, min_X, max_X),
                Mathf.Clamp(target.position.y, min_Y, max_Y), 
                -10), cameraSpeed * Time.deltaTime
                );
            }
        }
    }

    void parallaxEffect()
    {

        amountMoveCanvas.x = transform.position.x;
        amountMoveCanvas.y = transform.position.y;

        farBackground.position = Vector2.Lerp(farBackground.position, new Vector2(amountMoveCanvas.x, amountMoveCanvas.y), cameraSpeedParallax * Time.deltaTime);
        middleBackGround.position = Vector2.Lerp(middleBackGround.position, new Vector2(amountMoveCanvas.x, 0f) * .3f, cameraSpeedParallax * Time.deltaTime);

        if (theRb.velocity.y <= -22)
        {
            farBackground.position = Vector2.Lerp(farBackground.position, new Vector2(transform.position.x, transform.position.y), cameraSpeedFall * Time.deltaTime);
            middleBackGround.position = Vector2.Lerp(middleBackGround.position, new Vector2(amountMoveCanvas.x, 0f) * .3f, cameraSpeedFall * Time.deltaTime);
        }
    }

    public void updateCanvas(bool update)
    {
        updateCanvasY = true;
    }

    public void defaultCanvas()
    {
        updateCanvasY = false;
    }

    public void saveDeffault()
    {
        defaultMax_X = max_X;
        defaultMax_Y = max_Y;
        defaultMin_X = min_X;
        defaultMin_Y = min_Y;
    }

    public void loadDefault()
    {
        max_X = defaultMax_X;
        max_Y = defaultMax_Y;
        min_X = defaultMin_X;
        min_Y = defaultMin_Y;
    }

    public void skipToPlayer()
    {
        isSkipToPlayer = true;
        if (isSkipToPlayer)
        {
            transform.position = new Vector3(
            Mathf.Clamp(target.position.x, min_X, max_X),
            Mathf.Clamp(target.position.y, min_Y, max_Y),
            -10);

            amountMoveCanvas.x = transform.position.x;
            amountMoveCanvas.y = transform.position.y;
            farBackground.position = new Vector3(amountMoveCanvas.x, amountMoveCanvas.y, 0);
            middleBackGround.position = new Vector3(amountMoveCanvas.x, 0, 0) * .3f;

            isSkipToPlayer = false;
        }
    }
}
