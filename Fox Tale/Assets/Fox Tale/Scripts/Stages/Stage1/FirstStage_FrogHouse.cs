using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStage_FrogHouse : MonoBehaviour
{
    public static FirstStage_FrogHouse instance;

    public TextActivate FrogA;
    public TextActivate FrogB;
    public TextActivate FrogC;
    public bool barrageOpened;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (FrogA.hasTalked && FrogB.hasTalked && FrogC.hasTalked)
        {
            barrageOpened = true;
        }
    }
}
