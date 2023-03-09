using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraController : MonoBehaviour
{
    private Camera camera;
    public Vector3 cameraPos = new Vector3(0,-5,-10);
    public float offset = 0.03f;
    private float shakeTime;
    private void Awake()
    {
        camera = Camera.main;
    }

    IEnumerator Start()
    {
        shakeTime = 0.3f;

        while (shakeTime > 0.0f)
        {
            shakeTime -= Time.deltaTime;
            
            yield return null;
            camera.transform.position = new Vector3(
                Random.Range(cameraPos.x-0.03f, cameraPos.x+0.03f),
                Random.Range(cameraPos.y-0.03f, cameraPos.y+0.03f), -10.0f);

        }

        camera.transform.position = cameraPos;
        Destroy(this.gameObject);
    }

    
    void Update()
    {
    }
}
