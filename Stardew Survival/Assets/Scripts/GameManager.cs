using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public float playerSpeed = 6.0f;
    public float maxPlayerHP = 100f;

    [Header("PlayerResource")]
    public int playerMoney;
    public int playerSeed1;
    public int playerSeed2;
    public int playerSeed3;
    public int playerFertilizer;
    //플레이어 돈과 씨앗 3가지 소지, 비료

    [Header("DayChange")]
    public bool isDay = true;                   //낮이면 true
    public int dayCount;
    public float nightTime = 5.0f;              //낮 = 제한시간 X, 밤 = 일정시간 이후 낮으로
    public float nightTimer = 0f;
    public DayManager dayManager;
    public Home home;

    [Header("GardenStatus")]
    public int[] gardenPrice = new int[3];      //3단계의 가치
    public float[] gardenMaxHpArr = new float[10];  //밭의 최대 HP 배열

    [Header("SpawnManager & Enemy")]
    public float spawnRate;                     //적 스폰 간격 (스폰 사이의 시간간격)
    public float dropFertilizerRate;            //비료 드랍률 (하루에 몇 개 정도?) 

    public float enemyMaxHp;                    //적의 최대 HP, 이것도 day 지날수록 늘리기?
    public float enemyDps;                      //초당 데미지를 얼마나 줄지
    public float enemySpeed;                    //적의 스피드

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
