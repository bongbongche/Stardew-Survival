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
    public int playerFertilizer;
    public int playerSeed1;
    public int playerSeed2;
    public int playerSeed3;
    //�÷��̾� ���� ���� 3���� ����, ���

    [Header("DayChange")]
    public bool isDay = true;                               //���̸� true
    public int dayCount;
    public float nightTime = 5.0f;                          // �� = ���ѽð� X, �� = �����ð� ���� ������
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
    }//DayChange() ��� �� ��, �� ����. ���� �������� ������ DayManager ��ũ��Ʈ�� ����
}
