using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = transform.up * BulletManager.
            Instance.commonBulletData.bulletSpeed *350 *  Time.deltaTime;
    }

    public void test()
    {
        
    }
}
