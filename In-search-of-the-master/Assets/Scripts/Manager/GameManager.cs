using System;
using System.Collections;
using System.Collections.Generic;
using InspectorGadgets.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        set;
        get;
    }
    
    private PlayerController Controller;
    public bool _isGameStarted = false;
    
    // UI, UI 필드
    public Text ScoreText;
    public float Score;
    public Text CoinText;
    public float Coin;
    public int CoinPlus = 1;
    public Text ScoreCount;
    public Text CoinCount;
    public GameObject GameoverUI;
    #region HP
    [SerializeField]
    private Sprite[] HP = new Sprite[2];
    [SerializeField]
    private Image[] HPUI = new Image[3];
    #endregion
    static public float HighScore;

    public float ScoreTimer;
    public float IncreaseTime;
    private void Start()
    {
        Instance = this;
        Controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        UpdateScore();
        ScoreTimer = 0.0f;
        IncreaseTime = 0.5f;
        ScoreCount.text = "";
        CoinCount.text = "";
        GameoverUI.SetActive(false);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MAP_01_A" && MobileInput.Instance.tap && _isGameStarted == false)
        {
            _isGameStarted = true;
            Controller.StartRunning();
        }

        if (_isGameStarted == true)
        {
            ScoreText.text = "Score : " + Score;
            CoinText.text = "Coin : " + Coin;
            ScoreTimer += Time.deltaTime;
            if (ScoreTimer > IncreaseTime)
            {
                ScoreTimer = 0.0f;
                Score += 8;
            }
        }
    }

    public void SetHP()
    {
        for(int i =0; i < 3; i++)
        {
            HPUI[i].sprite = Controller.Hp < i + 1 ? HP[0] : HP[1];
        }
    }

    public void SetHP()
    {
        for(int i =0; i < 3; i++)
        {
            HPUI[i].sprite = Controller.Hp < i + 1 ? HP[0] : HP[1];
        }
    }

    public void GetCoin()
    {
        Coin += CoinPlus;
    }
    
    public void UpdateScore()
    {
        ScoreText.text = "Score : " + Score.ToString();
        CoinText.text = "Coin : " + Coin.ToString();
        
    }

    public void GameOver()
    {
        _isGameStarted = false;
        Controller._isRunning = false;
        Time.timeScale = 0;
        ScoreCount.text = Score.ToString();
        CoinCount.text = Coin.ToString();
        GameoverUI.SetActive(true);
        HighScore = Score;
        
        // 점수, 코인 초기화
        Score = 0;
        Coin = 0;
    }

}
