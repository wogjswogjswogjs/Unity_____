using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 dir;
    void Start()
    {
        // 스크립트가 실행됐을 떄, 1회실행(게임 오브젝트가 비활성화 되어있으면 실행x 씹힘)
    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        dir = new Vector3(horizontal, vertical, 0);
        
        transform.Translate(dir.normalized * speed * Time.deltaTime);
    }

}