using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 newCamPos = Player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, newCamPos, transform.position.magnitude);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
