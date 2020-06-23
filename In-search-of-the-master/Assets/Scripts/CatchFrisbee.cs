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
    private float distance = 5f;

    private void Start()
    {
        isCatch = false;
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
                Destroy(gameObject);
            }
        }

        if (Vector3.Distance(player.transform.position, gameObject.transform.position) > distance && !isCatch)
        {
            // 플레이어와 거리가 멀어지면 사라짐
            text.text = "MISS..";
            startTime += Time.deltaTime;
            if (startTime >= lastTime)
            {
                text.text = " ";
                Destroy(gameObject);
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
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 100);
        }
    }
}
