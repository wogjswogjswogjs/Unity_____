using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public Test1 testObject;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        Debug.Log("Start" + testObject.testInt);
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
