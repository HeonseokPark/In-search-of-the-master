using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{
    // 메인화면 내 사용 변수
    public GameObject shopUI;
    public GameObject mainUI;
    public GameObject optionUI;

    // 인게임 내 사용 변수
    public GameObject pauseMenuUI; // 일시정지 했을 때 나오는 UI
    public Text countText; // 게임 재개를 눌렀을 때 나오는 카운팅 UI

    bool isPause, isRoad;
    public float countNum;
    float startTime;
    float lastTime;

    private void Start()
    {
        isPause = false; isRoad = false;
        startTime = Time.realtimeSinceStartup;
    }

    private void Update()
    {
        // 게임 재개 카운트 부문
        if (isRoad)
        {
            countNum -= lastTime;
            if (countNum <= 1)
            {
                countText.gameObject.SetActive(false);
                Time.timeScale = 1;
                isRoad = false;
            }
        }
        //countText.text = $"{(int)countNum}";
        lastTime = Time.realtimeSinceStartup - startTime;
        startTime = Time.realtimeSinceStartup;
    }

    public void pauseButton()
    {
        // 일시정지 부문
        if (isPause == false)
        {
            Time.timeScale = 0;
            pauseMenuUI.gameObject.SetActive(true);
            isPause = true;
        }
    }

    public void menuButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void reloadButton()
    {
        // 게임 재개 부문
        isRoad = true; isPause = false;
        countNum = 4;
        pauseMenuUI.gameObject.SetActive(false);
        countText.gameObject.SetActive(true);
    }

    public void restartButton()
    {
        // 게임 재시작
        GameManager.Instance.Coin = 0;
        GameManager.Instance.Score = 0;
        SceneManager.LoadScene("MAP_01_A");
    }

    public void startButton()
    {
        SceneManager.LoadScene("MAP_01_A");
    }

    public void shopButton()
    {
        shopUI.SetActive(true);
        mainUI.SetActive(false);
    }

    public void optionButton()
    {
        optionUI.SetActive(true);
    }

    public void backShopButton()
    {
        shopUI.SetActive(false);
        mainUI.SetActive(true);
    }

    public void backOptionButton()
    {
        optionUI.SetActive(false);
    }
}
