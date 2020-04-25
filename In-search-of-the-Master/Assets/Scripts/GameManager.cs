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
    
    // UI, UI 필드
    public Text ScoreText;
    public float Score;

    private void Awake()
    {
        Instance = this;
        UpdateScore();
        Controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        
    }

    public void UpdateScore()
    {
        ScoreText.text = "Score : " + Score.ToString();
        
    }
}
