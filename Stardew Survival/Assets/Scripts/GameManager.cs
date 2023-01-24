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
    //�÷��̾� ���� ���� 3���� ����, ���

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
    public bool isDay = true;                       //���̸� true
    public int dayCount;
    public float nightTime = 5.0f;                  // �� = ���ѽð� X, �� = �����ð� ���� ������
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
    public int[] sellSeedPrice = new int[3];        // 0: seed1 ����, 1: seed 2����, 2: seed3 ����


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
        //���� ���� �� �־����� �ʱ� ��ǰ, �ӽ�����

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

        // �÷��̾� ������ ������Ʈ
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
    }//DayChange() ��� �� ��, �� ����. ���� �������� ������ DayManager ��ũ��Ʈ�� ����
}
