using UnityEngine;
using Pixeye.Unity;

public class EnemyController : MonoBehaviour
{
    //public static EnemyController instance;

    [Foldout("Get Components", true)]
    public Transform[] points;
    public Transform enemySpritePosition;
    public SpriteRenderer theSR;
    private Animator anim;
    [Foldout("Movement", true)]
    public int currentPoint;
    public float moveSpeed;
    public float moveTime, waitTime;
    public float moveCount, waitCount;

    [Foldout("Debug", true)]
    public bool isPatrol;
    public bool isWaiting;

    void Start()
    {

        anim = GetComponentInParent<Animator>();
        moveCount = moveTime;
    }

    void Update()
    {
        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;
            patrolState2();
        }
        else if (waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            waitState();
        }
    }

    private void patrolState2()
    {
        anim.SetBool("isMoving", true);
        isWaiting = false;
        isPatrol = true;
        enemySpritePosition.position = Vector2.MoveTowards(enemySpritePosition.position, points[currentPoint].position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(enemySpritePosition.position, points[currentPoint].position) < 0.5f)
        {
            currentPoint++;

            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
        }

        if (transform.position.x < points[currentPoint].position.x)
        {
            theSR.flipX = true;
        }
        else if (transform.position.x > points[currentPoint].position.x)
        {
            theSR.flipX = false;
        }

        if (moveCount <= 0)
        {
            waitCount = waitTime;
        }
    }


    private void waitState()
    {
        isWaiting = true;
        isPatrol = false;
        anim.SetBool("isMoving", false);

        if (waitCount <= 0)
        {
            moveCount = moveTime;
        }
    }

}