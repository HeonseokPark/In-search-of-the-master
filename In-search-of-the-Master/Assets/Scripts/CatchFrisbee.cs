using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchFrisbee : MonoBehaviour
{
    private Text text; // 화면 중앙에 뜨는 문구
    private GameObject player;

    private bool isCatch; // 플레이어가 잡았는지 여부
    private float startTime = 0f;
    private float lastTime = 1.5f; // 화면 중앙에 뜨는 문구의 시간

    private void Start()
    {
        text = GameObject.Find("FrisbeeUI").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (isCatch)
        {
            startTime += Time.deltaTime;
            if (startTime >= lastTime)
            {
                startTime = 0f;
                text.text = " ";
                isCatch = false;
            }
        }

        if (Vector3.Distance(player.transform.position, gameObject.transform.position) > 20f)
        {
            // 플레이어와 거리가 멀어지면 사라짐
            Destroy(gameObject);
            text.text = "MISS..";
            startTime += Time.deltaTime;
            if (startTime >= lastTime)
            {
                text.text = " ";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            text.text = "Catch!!";
            isCatch = true;
            GameManager.Instance.Coin += 30;
            GameManager.Instance.Score += 300;
            Destroy(gameObject);
        }
    }
}
