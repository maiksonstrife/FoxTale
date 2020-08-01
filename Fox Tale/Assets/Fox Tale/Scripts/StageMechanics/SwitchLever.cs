using UnityEngine;

public class SwitchLever : MonoBehaviour
{
    public GameObject objectToSwitch;
    public Sprite leverDownSprite;
    public Sprite leverUpSprite;
    public GameObject exclamationMark;
    private SpriteRenderer theSR;
    private bool isLeverUp = true;

    public bool playerDetected;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerDetected)
        {
            if(Input.GetKeyDown(KeyCode.B))
            {
                if (isLeverUp)
                {
                    objectToSwitch.SetActive(true);
                    theSR.sprite = leverDownSprite;
                    isLeverUp = false;
                }
                else
                {
                    objectToSwitch.SetActive(false);
                    theSR.sprite = leverUpSprite;
                    isLeverUp = true;
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            exclamationMark.SetActive(true);
            playerDetected = true;
        }           
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
            exclamationMark.SetActive(false);
        }
    }

}
