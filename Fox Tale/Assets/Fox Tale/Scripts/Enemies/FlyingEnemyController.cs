using UnityEngine;
using Pixeye.Unity;

public class FlyingEnemyController : MonoBehaviour
{
    
    [Foldout("Get Components", true)]
    public Transform[] points;
    public Transform enemySpritePosition;
    public SpriteRenderer theSR;

    [Foldout("Movement", true)]
    public float moveSpeed;
    public int currentPoint;

    [Foldout("Attack", true)]
    public float detectionRange, chaseSpeed;
    public float waitAfterAttack;
    private Vector2 targetDetected;
    private float waitAfterAttackCounter;

    void Update()
    {

        if (waitAfterAttackCounter > 0)
        {
            waitAfterAttackCounter -= Time.deltaTime;
            patrolState();
        }
        else
        {
            if (Vector2.Distance(enemySpritePosition.position, PlayerController.instance.transform.position) > detectionRange)
            {
                targetDetected = Vector2.zero;
                patrolState();
            }
            else
            {
                attackState();
            }
        }
    }

    private void patrolState()
    {
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
    }

    private void attackState()
    {
        if (targetDetected == Vector2.zero)
        {
            targetDetected = PlayerController.instance.transform.position;
        }

        enemySpritePosition.position = Vector2.MoveTowards(enemySpritePosition.position, targetDetected, chaseSpeed * Time.deltaTime);

        if(Vector2.Distance(enemySpritePosition.position, targetDetected) <= .1f)
        {
            waitAfterAttackCounter = waitAfterAttack;
            targetDetected = Vector2.zero;
        }
    }

}
