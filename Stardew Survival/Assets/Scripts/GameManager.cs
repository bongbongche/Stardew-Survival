using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public float playerSpeed = 6.0f;
    public float maxPlayerHP = 100f;

    [Header("DayChange")]
    public bool isDay = true; //낮이면 true
    public DayManager dayManager;

    void Start()
    {
        dayManager = GameObject.Find("DayManager").GetComponent<DayManager>();
    }

    void Update()
    {

    }

    public void DayChange()
    {
        if (isDay)
        {
            isDay = false;
            dayManager.TurnsToNight();
        }
        else
        {
            isDay = true;
            dayManager.TurnsToDay();
        }
    }//DayChange() 사용 시 낮, 밤 변경. 이후 세부적인 내용은 DayManager 스크립트로 조정
}
