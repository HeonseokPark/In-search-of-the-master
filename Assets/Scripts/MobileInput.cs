using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class MobileInput : MonoBehaviour
{
    private const float DEADZONE = 200.0f;
    public static MobileInput Instance
    {
        set;
        get;
    }
    
    private bool Tap, SwipeLeft, SwipeRight, SwipeUp, SwipeDown;
    private Vector2 SwipeDelta, StartTouch;

    public bool tap
    {
        get
        {
            return Tap;
        }
    }
    public Vector2 swipeDelta
    {
        get
        {
            return SwipeDelta;
        }
    }
    public bool swipeLeft
    {
        get
        {
            return SwipeLeft;
        }
    }
    public bool swipeRight
    {
        get
        {
            return SwipeRight;
        }
    }
    public bool swipeUp
    {
        get
        {
            return SwipeUp;
        }
    }
    public bool swipeDown
    {
        get
        {
            return SwipeDown;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        
        //bool 전부 false로
        Tap = SwipeLeft = SwipeRight = SwipeDown = SwipeUp = false;

        #region Standalone Inputs

        if (Input.GetMouseButtonDown(0))
        {
            Tap = true;
            StartTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StartTouch = SwipeDelta = Vector2.zero;
        }
        #endregion
        
        #region Mobile Inputs

        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Tap = true;
                StartTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                StartTouch = SwipeDelta = Vector2.zero;
            }
        }
        #endregion
        
        // 거리 계산
        SwipeDelta = Vector2.zero;
        if (StartTouch != Vector2.zero)
        {
            //모바일 체크
            if (Input.touches.Length != 0)
            {
                SwipeDelta = Input.touches[0].position - StartTouch;
            }
            //스탠드얼론 체크
            else if (Input.GetMouseButton(0))
            {
                SwipeDelta = (Vector2)Input.mousePosition - StartTouch;
            }
        }
        
        //Deadzone을 벗어났는지 확인
        if (SwipeDelta.magnitude > DEADZONE)
        {
            float x = SwipeDelta.x;
            float y = SwipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                {
                    SwipeLeft = true;
                }
                else
                {
                    SwipeRight = true;
                }
            }
            else
            {
                //Up or Down
                if (y < 0)
                {
                    SwipeDown = true;
                }
                else
                {
                    SwipeUp = true;
                }
            }

            StartTouch = SwipeDelta = Vector2.zero;
        }
    }
}
