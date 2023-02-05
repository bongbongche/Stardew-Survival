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
    public float nightTime = 30.0f;                  // �� = ���ѽð� X, �� = �����ð� ���� ������
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
    public int[] sellSeedPrice = new int[3];        // 0: seed1 ����, 1: seed 2����, 2: seed3 ����
    public int[] upgradeWeaponPrice = new int[2];   // 0: 0->1, 1: 1->2 
    public int   sellFertilizerPrice;

    [Header("UI")]
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI dayText;

    [Header("Daybalance(%)")]
    public float balanceEnemyHp;
    public float balanceEnemySpeed;
    public float balanceEnemyDps;
    public float balanceEnemySpawnRate;



    // �÷��̾� ������ ������ ����
    private float xBound = 8.5f;
    private float yBound = 5f;
    private float playerSpriteLength = 1.2f;

    void Start()
    {
        dayManager = GameObject.Find("Day Manager").GetComponent<DayManager>();
        dayCount = 0;

        moneyText.text = "$: " + playerMoney;
        dayText.text = "Day: " + dayCount;
        enemyKillCount = 0;
    }

    void Update()
    {
        if(!isDay)
        {
            if (nightTimer >= 0.1f)
            {
                nightTimer -= Time.deltaTime;

            }
            else
                DayChange();
        }

        // �÷��̾� ������ ������Ʈ
        moneyText.text = "$: " + playerMoney;

        // �÷��̾� �̵� ���� ����
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
    }//DayChange() ��� �� ��, �� ����. ���� �������� ������ DayManager ��ũ��Ʈ�� ����

    public void DayBalance()
    {
        randomBalance = Random.Range(0, 3);
        switch (randomBalance)
        {
            case 0:
                enemyMaxHp *= (1 + balanceEnemyHp / 100);
                break;
            case 1:
                enemySpeed *= (1 + balanceEnemySpeed / 100);
                break;
            case 2:
                enemyDps *= (1 + balanceEnemyDps / 100);
                break;
            case 3:
                spawnRate *= (1 - balanceEnemySpawnRate / 100);
                break;
        }
    }//DayBalance() ��� ��, ���̵� ����(��¥�� �������� ���̵� ����)
    //�ӽ�, ���氡��, ��ġ ���� �ø���
}
