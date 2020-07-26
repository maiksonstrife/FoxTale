using UnityEngine;

public class Drop : MonoBehaviour
{
    [Range(0, 100)] public float chanceToDrop;
    private float dropSelect;
    public GameObject drop;
    public Transform spriteLocation;


    // Start is called before the first frame update
    void Start()
    {
        dropSelect = Random.Range(0, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void itemDrop()
    {
        if (dropSelect <= chanceToDrop)
        {
            Invoke("droppedItem", .15f);
        }
    }

    private void droppedItem()
    {
        Instantiate(drop, spriteLocation.position, spriteLocation.rotation);
    }

}
