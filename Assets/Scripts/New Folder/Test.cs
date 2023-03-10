using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject test;
    ResourceManager rm = new ResourceManager();
    void Start()
    {
        //test = ResourceManager.LoadAddressable<GameObject>("Test");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        { 
            //rm.LoadAddressable("Test");
            // rm.ReleaseAddressable();
            StartCoroutine(TestCoroutine());
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }

    IEnumerator TestCoroutine()
    {
        rm.LoadAddressable("Test");
        yield return new WaitForSeconds(3.0f);
        Debug.Log(rm.Handle.Result.GetType());
        Debug.Log(test.GetType());
    }
}
