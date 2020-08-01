using UnityEngine;

public class BossTankController : MonoBehaviour
{
    public enum bossStates { shooting, hurt, moving, ended };
    public bossStates currentState;

    public Transform TheBoss;
    public Animator anim;

    [Header("Movement")]
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool moveRight;
    public GameObject mine;
    public Transform minePoint;
    public float timeBetweenMines;
    private float mineCounter;

    [Header("Shooting")]
    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;

    [Header("Hurt")]
    public float hurtTime;
    private float hurtCounter;
    public GameObject hitBox;

    [Header("Health")]
    public int health = 5;
    public GameObject explosion, platformEnding;
    private bool isDefeated;
    public float shotSpeedUp;
    public float mineSpeedUp;



    // Start is called before the first frame update
    void Start()
    {
        currentState = bossStates.shooting;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case bossStates.shooting:
                bossShoot();
                break;

            case bossStates.hurt:
                bossHurt();
                break;

            case bossStates.moving:
                bossMove();
                dropMines();
                break;

            case bossStates.ended:
                break;
        }
    }

    //stateMachine
    public void takeHit()
    {
        currentState = bossStates.hurt;
        hurtCounter = hurtTime;
        anim.SetTrigger("Hit");
        AudioManager.instance.playSFX(0);
        BossTankMine[] mines = FindObjectsOfType<BossTankMine>();
        if (mines.Length > 0)
        {
            foreach (BossTankMine foundMine in mines)
            {
                foundMine.explodeMines();
            }
        }

        health--;
        if(health <= 0)
        {
            isDefeated = true;
        }
        else
        {
            timeBetweenShots /= shotSpeedUp;
            timeBetweenMines /= mineSpeedUp;
        }
    }

    private void bossShoot()
    {
        shotCounter -= Time.deltaTime;
        
        if(shotCounter <= 0)
        {
            shotCounter = timeBetweenShots;
            var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            newBullet.transform.localScale = TheBoss.localScale;
        }
    }

    private void bossHurt()
    {
        if (hurtCounter > 0)
        {
            hurtCounter -= Time.deltaTime;

            if (hurtCounter <= 0)
            {
                currentState = bossStates.moving;
                mineCounter = 0;
                if (isDefeated)
                {
                    TheBoss.gameObject.SetActive(false);
                    Instantiate(explosion, TheBoss.position, TheBoss.rotation);
                    platformEnding.SetActive(true);
                    AudioManager.instance.stopBossMusic();
                    currentState = bossStates.ended;
                }
            }
        }
    }

    private void bossMove()
    {
        if (moveRight)
        {
            TheBoss.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

            if (TheBoss.position.x > rightPoint.position.x)
            {
                TheBoss.localScale = Vector3.one; //not flipping cause the child object needs to change sides too
                moveRight = false;
                endMovement();
            }
        }
        else
        {
            TheBoss.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

            if (TheBoss.position.x < leftPoint.position.x)
            {
                TheBoss.localScale = new Vector3(-1f, 1f, 1f); //not flipping cause the child object needs to change sides too
                moveRight = true;
                endMovement();
            }
        }
    }

    private void endMovement()
    {
        currentState = bossStates.shooting;
        shotCounter = 0f;
        anim.SetTrigger("StopMoving");
        hitBox.SetActive(true);
    }

    private void dropMines()
    {
        mineCounter -= Time.deltaTime;
        if(mineCounter <= 0)
        {
            mineCounter = timeBetweenMines;
            Instantiate(mine, minePoint.position, minePoint.rotation);
        }
    }

}
