using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject effecttest;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1.0f);
    }

    void Update()
    {
        rb.velocity = transform.up * BulletManager.
            Instance.commonBulletData.bulletSpeed *700 *  Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        GameObject camera = new GameObject("Camera Test");
        camera.AddComponent<CameraController>();
        GameObject effect = EffectManager.Instance.LoadEffect();
        Instantiate(effect, collision.transform.position, Quaternion.identity);
    }
    
    
}
