using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public BulletData commonBulletData;
    
    private static BulletManager instance = null;
    public static BulletManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public GameObject LoadBullet()
    {
        return commonBulletData.bulletPrefab;
    }

    public void InstantiateBullet(Vector3 pos)
    {
        
    }
}
