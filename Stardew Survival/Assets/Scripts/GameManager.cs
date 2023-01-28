using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
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

    [Header("Weapon")]
    [Space(10f)]
    public float weapon1Radius;
    public float weapon1AttackSpeed;
    public float weapon1Damage;
    public float weapon1Knockback;
    [Space(10f)]
    public float weapon2Radius;
    public float weapon2AttackSpeed;
    public float weapon2Damage;
    public float weapon2Knockback;
    [Space(10f)]
    public float weapon3Radius;
    public float weapon3AttackSpeed;
    public float weapon3Damage;
    public float weapon3Knockback;

    [Header("DayChange")]
    public bool isDay = true;                       //낮이면 true
    public int dayCount;
    public float nightTime = 5.0f;                  // 낮 = 제한시간 X, 밤 = 일정시간 이후 낮으로
    public float nightTimer = 0f;
    public DayManager dayManager;
    public Home home;

    [Header("GardenStatus")]
    public int[] gardenPrice = new int[3];      
    public float[] gardenMaxHpArr = new float[10];  

    [Header("SpawnManager & Enemy")]
    public float    spawnRate;
    public int      enemyKillCount;
    public int      getFertilizerPerKill;
    public float    enemyMaxHp;                        
    public float    enemyDps;                          
    public float    enemySpeed;
    private int randomBalance;

    [Header("Shop")]
    public int[] sellSeedPrice = new int[3];        // 0: seed1 가격, 1: seed 2가격, 2: seed3 가격
    public int[] upgradeWeaponPrice = new int[2];   // 0: 0->1, 1: 1->2 

    [Header("UI")]
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI dayText;

    // 플레이어 움직임 제한할 범위
    private float xBound = 8.5f;
    private float yBound = 5f;
    private float playerSpriteLength = 1.2f;

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
        dayText.text = "Day: " + dayCount;
        enemyKillCount = 0;
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

        // 플레이어 이동 범위 제한
        if (player.transform.position.x > xBound)
        {
            player.transform.position = new Vector3(xBound, player.transform.position.y, 0);
        }
        if (player.transform.position.x < -xBound)
        {
            player.transform.position = new Vector3(-xBound, player.transform.position.y, 0);
        }
        if (player.transform.position.y > yBound - playerSpriteLength)
        {
            player.transform.position = new Vector3(player.transform.position.x, yBound - playerSpriteLength, 0);
        }
        if (player.transform.position.y < -yBound)
        {
            player.transform.position = new Vector3(player.transform.position.x, -yBound, 0);
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

    public void DayBalance()
    {
        randomBalance = Random.Range(0, 3);
        switch (randomBalance)
        {
            case 0:
                enemyMaxHp *= 1.05f;
                break;
            case 1:
                enemySpeed *= 1.05f;
                break;
            case 2:
                enemyDps *= 1.05f;
                break;
            case 3:
                spawnRate *= 0.95f;
                break;
        }
    }//DayBalance() 사용 시, 난이도 증가(날짜가 지날수록 난이도 증가)
    //임시, 변경가능
}
