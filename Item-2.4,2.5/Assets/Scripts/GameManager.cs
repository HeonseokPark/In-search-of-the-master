using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        set;
        get;
    }
    
    private PlayerController Controller;
    private bool _isGameStarted = false;
    
    // UI, UI 필드
    public Text ScoreText;
    public float Score;
    public Text CoinText;
    public float Coin;
    public int CoinPlus = 1;

    public float ScoreTimer;
    public float IncreaseTime;
    private void Awake()
    {
        Instance = this;
        Controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        UpdateScore();
        ScoreTimer = 0.0f;
        IncreaseTime = 0.5f;
    }

    private void Update()
    {
        if (MobileInput.Instance.tap && _isGameStarted == false)
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

    public void GetCoin()
    {
        Coin += CoinPlus;
    }
    
    public void UpdateScore()
    {
        ScoreText.text = "Score : " + Score.ToString();
        CoinText.text = "Coin : " + Coin.ToString();
        
    }
    
}
