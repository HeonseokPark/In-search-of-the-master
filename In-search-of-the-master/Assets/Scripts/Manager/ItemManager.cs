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
        Item_Magnatic,
        Item_GodMode,
        Item_DoubleCoin,
        Item_Heal,
    }

    private ItemList itemlist;

    public GameObject[] coins;
    private PlayerController player;
    private const float LANE_DISTANCE = 6.0f;

    public float[] distances;
    public bool isShield;
    public float startTime = 0;
    public float lastTime; //아이템 지속시간

    private int itemAmount = 99;
    private float speed = 10f; //날아가는 속도
    private Vector3 position; //플레이어 위치
    private string currentItem; //현재 아이템
    //아이템 가격들
    private int ItemPrice_Magnatic = 500;
    private int ItemPrice_GodMode = 1000;
    private int ItemPrice_DoubleCoin = 400;
    private int ItemPrice_Heal = 500;

    private void Start()
    {
        Instance = this;
        lastTime = 3f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        itemlist = ItemList.None;
    }

    private void Update()
    {
        switch (itemlist)
        {
            //자석
            case ItemList.Item_Magnatic:
                startTime += Time.deltaTime;
                MagnetEffect();
                if (lastTime <= startTime)
                {
                    startTime = 0f;
                    itemlist = ItemList.None;
                }
                break;
            case ItemList.Item_GodMode:
                startTime += Time.deltaTime;
                if (lastTime <= startTime)
                {
                    startTime = 0f;
                    player.moveSpeed /= 2f;
                    isShield = false;
                    itemlist = ItemList.None;
                }
                break;
            case ItemList.Item_Heal:
                break;
            case ItemList.Item_DoubleCoin:
                startTime += Time.deltaTime;
                if (lastTime <= startTime)
                {
                    startTime = 0f;
                    GameManager.Instance.CoinPlus = 1;
                    itemlist = ItemList.None;
                }
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
            case "Item_Magnatic":
                itemlist = ItemList.Item_Magnatic;
                break;
            case "Item_GodMode":
                itemlist = ItemList.Item_GodMode;
                isShield = true; //무적
                player.moveSpeed *= 2f; //이동속도 두배
                break;
            case "Item_Heal":
                itemlist = ItemList.Item_Heal;
                if (player.Hp < 3)
                    player.Hp += 1; //회복
                GameManager.Instance.SetHP();
                itemlist = ItemList.None;
                break;
            case "Item_DoubleCoin":
                itemlist = ItemList.Item_DoubleCoin;
                GameManager.Instance.CoinPlus = 2;
                break;
            default:
                startTime = 0f;
                itemlist = ItemList.None;
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
