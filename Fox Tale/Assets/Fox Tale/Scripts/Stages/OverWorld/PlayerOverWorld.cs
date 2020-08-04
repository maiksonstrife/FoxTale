using UnityEngine;

public class PlayerOverWorld : MonoBehaviour
{
    private bool isAndroid = true;
    public bool isPc = false;
    private float axisHorizontal;
    private float axisVertical;
    private bool isJump;
    private bool levelLoading;
    public MapPoint currentPoint;
    public float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkInput(); 
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, currentPoint.transform.position) < .1f && !levelLoading)
        {

            if (currentPoint.isLevel == true && currentPoint.isLocked)
            {
                OverworldUIController.instance.showInfoLocked();
            }

            if (currentPoint.isLevel == true && !currentPoint.isLocked)
            {
                OverworldUIController.instance.showInfo(currentPoint);
                if (isJump)
                {
                    levelLoading = true;
                    AudioManager.instance.playSFX(4);
                    OverworldManager.instance.LoadLevel(currentPoint.levelToLoad);
                }
            }

            inputDirection();
        }
        else
        {
            isJump = false;
            axisHorizontal = 0;
        }
    }

    private void inputDirection()
    {
        if (axisHorizontal > .5f)
        {
            if (currentPoint.right != null)
            {
                setNextPoint(currentPoint.right);
            }
        }

        else if(axisHorizontal < -.5f)
        {
            if (currentPoint.left != null)
            {
                setNextPoint(currentPoint.left);
            }
        }

        else if (axisVertical > .5f)
        {
            if (currentPoint.up != null)
            {
                setNextPoint(currentPoint.up);
            }
        }

        else if (axisVertical < -.5f)
        {
            if (currentPoint.down != null)
            {
                setNextPoint(currentPoint.down);
            }
        }
    }

    private void setNextPoint(MapPoint nextPoint)
    {
        OverworldUIController.instance.hideInfo();
        AudioManager.instance.playSFX(5);
        currentPoint = nextPoint;
    }

    private void checkInput()
    {
        if (isAndroid)
        {
            axisHorizontal = Input.GetAxisRaw("Horizontal");
            axisVertical = Input.GetAxisRaw("Vertical");
        }
        else
        {
            axisHorizontal = Input.GetAxisRaw("Horizontal");
            axisVertical = Input.GetAxisRaw("Vertical");
        }

        if (Input.GetKeyDown(KeyCode.B) )
        {
            isJump = true;
        }
    }
}
