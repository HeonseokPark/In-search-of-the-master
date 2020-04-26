using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.GetCoin();
            Destroy(gameObject, 1.5f);
        }
    }
}
