using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance {
        set;
        get;
    }

    enum ItemList
    {
        None,
        Magnet,
        Shield,
        potion,
    }

    private ItemList itemlist;

    public GameObject[] coins;
    private PlayerController player;
    private const float LANE_DISTANCE = 6.0f;

    public float[] distances;
    public bool isShield;

    public float startTime = 0;
    public float lastTime; //아이템 지속시간
    private float speed = 10f; //날아가는 속도
    private Vector3 position; //플레이어 위치
    private string currentItem; //현재 아이템

    private void Start()
    {
        Instance = this;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        itemlist = ItemList.None;
    }

    private void Update()
    {
        switch (itemlist)
        {
            //자석
            case ItemList.Magnet:
                startTime += Time.deltaTime;
                MagnetEffect();
                if (lastTime <= startTime)
                {
                    startTime = 0f;
                    itemlist = ItemList.None;
                }
                break;
            case ItemList.Shield:
                startTime += Time.deltaTime;
                if (lastTime <= startTime)
                {
                    startTime = 0f;
                    player.moveSpeed /= 2f;
                    itemlist = ItemList.None;
                    isShield = false;
                }
                break;
            case ItemList.potion:
                break;
            default:
                break;
        }
    }

    public void CurrentItem(string _itemName)
    {
        currentItem = _itemName;

        switch (currentItem)
        {
            //자석
            case "Magnet":
                itemlist = ItemList.Magnet;
                lastTime = 5f;
                break;
            case "Shield":
                itemlist = ItemList.Shield;
                lastTime = 3f;
                isShield = true;
                player.moveSpeed *= 2f;
                break;
            case "Potion":
                itemlist = ItemList.potion;
                if (player.Hp < 3)
                    player.Hp += 1;
                itemlist = ItemList.None;
                break;
            default:
                lastTime = 0f;
                break;
        }
    }

    void MagnetEffect()
    {
        //코인 정보 불러오기
        coins = GameObject.FindGameObjectsWithTag("Coin");

        distances = new float[coins.Length];

        for (int i = 0; i < coins.Length; ++i)
        {
            //코인과 플레이어간의 거리 계산
            distances[i] = Vector3.Distance(player.transform.position, coins[i].transform.position);

            if (distances[i] <= LANE_DISTANCE + 0.5f)
            {
                //끌당
                coins[i].transform.LookAt(player.transform.position);
                coins[i].transform.Translate(Vector3.forward * Time.deltaTime * (speed + player.moveSpeed));
            }
        }
    }
}
