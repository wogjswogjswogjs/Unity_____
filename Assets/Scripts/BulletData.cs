using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletData",menuName = "Scriptable Object/Bullet Data", order = int.MaxValue)]
public class BulletData : ScriptableObject
{
    public string bulletName;
    public int bulletDamage;
    public float bulletSpeed;
    public GameObject bulletPrefab;
}
