using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public float speed;

    private GameObject player;

    public GameObject[] BG = new GameObject[7];
    public float[] BGScrollSpeed = new float[7];
    private Vector3 movement;
    
    void Start()
    {
        player = GameObject.Find("Player").gameObject;
    }
    
    void Update()
    {
        for (int i = 0; i < BG.Length; i++)
        {
            movement = new Vector3(
                Input.GetAxisRaw("Horizontal"), 0.0f, 0.0f);
                
            BG[i].transform.position -= movement * BGScrollSpeed[i] * Time.deltaTime;
        }
    }
}
