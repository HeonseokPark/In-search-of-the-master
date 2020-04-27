using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform LootAt;
    public Vector3 offset = new Vector3(0, 11.36248f, -18.50483f);
    
    private void Start()
    {
        transform.position = LootAt.position + offset;
    }
    private void LateUpdate()
    {
        Vector3 DesiredPosition = LootAt.position + offset;
        DesiredPosition.x = 0;
        transform.position = Vector3.Lerp(transform.position, DesiredPosition, Time.deltaTime);
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
