using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public float playerSpeed = 6.0f;
    public float maxPlayerHP = 100f;
    public float attackDelay = 0.3f;
    public float attackSpeed = 0.5f;

    [Header("PlayerResource")]
    public int playerMoney;
    public int playerFertilizer;
    public int playerSeed1;
    public int playerSeed2;
    public int playerSeed3;
    //플레이어 돈과 씨앗 3가지 소지, 비료

    [Header("DayChange")]
    public bool isDay = true;                       //낮이면 true
    public int dayCount;
    public float nightTime = 5.0f;                  // 낮 = 제한시간 X, 밤 = 일정시간 이후 낮으로
    public float nightTimer = 0f;
    public DayManager dayManager;
    public Home home;

    [Header("GardenStatus")]
    public int[] gardenPrice = new int[3];      
    public float[] gardenMaxHpArr = new float[10];  //

    [Header("SpawnManager & Enemy")]
    public float spawnRate;                         //
    public float dropFertilizerRate;                // 

    public float enemyMaxHp;                        //
    public float enemyDps;                          //
    public float enemySpeed;                        //

    [Header("Shop")]
    public int[] sellSeedPrice = new int[3];        // 0: seed1 가격, 1: seed 2가격, 2: seed3 가격


    [Header("UI")]
    public TextMeshProUGUI moneyText;

    void Start()
    {
        dayManager = GameObject.Find("Day Manager").GetComponent<DayManager>();
        dayCount = 0;

        playerMoney = 10;
        playerSeed1 = 5;
        playerSeed2 = 5;
        playerSeed3 = 5;
        playerFertilizer = 5;
        //게임 시작 시 주어지는 초기 물품, 임시적용

        moneyText.text = "$: " + playerMoney;
    }

    void Update()
    {
        if(!isDay)
        {
            if (nightTimer >= 0.1f)
                nightTimer -= Time.deltaTime;
            else
                DayChange();
        }

        // 플레이어 소지금 업데이트
        moneyText.text = "$: " + playerMoney;
    }

    public void DayChange()
    {
        if (isDay)
        {
            isDay = false;
            dayManager.TurnsToNight();
            nightTimer = nightTime;
        }
        else
        {
            isDay = true;
            dayCount++;
            dayManager.TurnsToDay();
        }
    }//DayChange() 사용 시 낮, 밤 변경. 이후 세부적인 내용은 DayManager 스크립트로 조정
}
