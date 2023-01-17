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
    //�÷��̾� ���� ���� 3���� ����, ���� �Ⱦ���

    [Header("DayChange")]
    public bool isDay = true;                               //���̸� true
    public int dayCount;
    public float nightTime = 5.0f;                          // �� = ���ѽð� X, �� = �����ð� ���� ������
    public float nightTimer = 0f;
    public DayManager dayManager;
    public Home home;

    void Start()
    {
        dayManager = GameObject.Find("Day Manager").GetComponent<DayManager>();
        dayCount = 0;
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
