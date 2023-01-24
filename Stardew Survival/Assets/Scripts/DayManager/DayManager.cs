using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//�㳷 ���� ��, �������� ������� ������Ʈ ���� ��ũ��Ʈ
public class DayManager : MonoBehaviour
{
    [Header("�㳷����")]
    public SpritesOnCamera spriteOnCamera; // ����Ƽ���� ����

    [Header("�ٸ� ��ũ��Ʈ��� ����")]
    private PlayerController playerController;
    private GameManager gameManager;

    [Header("�ٸ� �ü���� ����")]
    public GameObject home;
    public GameObject shop;
    public GameObject spawnManager;
    public GameObject reportUI;
    public GameObject playerHPBar;
    public GameObject playerInventory;
    public GameObject nightTimerBar;
    public TextMeshProUGUI reportFertilizer;

    [Header("�÷��̾�� ����")]
    private GameObject player;
    public GameObject playerLight;


    void Start()
    {
        player = GameObject.Find("Player");
        playerLight.SetActive(false);
        playerController = player.GetComponent<PlayerController>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    public void TurnsToNight()
    {
        home.SetActive(false);

        shop.SetActive(false);                      //������ ����

        playerLight.SetActive(true);                //�÷��̾� �ֺ� �� ����
        playerController.playerMode = 9;            //�÷��̾� ��� ����
        playerHPBar.SetActive(true);
        playerInventory.SetActive(false);
        nightTimerBar.SetActive(true);

        spawnManager.GetComponent<SpawnManager>().spawnActive = true;              //�����Ŵ��� ON

        spriteOnCamera.ColorToNight();
    }//���� �� �� �۵���Ű�� �͵�

    public void TurnsToDay()
    {
        home.SetActive(true);

        shop.SetActive(true);                       // ������ ����

        playerLight.SetActive(false);               //�÷��̾� �ֺ� �� ��
        playerController.playerMode = 1;            //�÷��̾� ��� ����
        playerController.currentPlayerHP = gameManager.maxPlayerHP; //�÷��̾� ü��ȸ��
        playerHPBar.SetActive(false);
        playerInventory.SetActive(true);
        nightTimerBar.SetActive(false);


        reportUI.SetActive(true);
        reportFertilizer.text = " "+ gameManager.enemyKillCount / gameManager.getFertilizerPerKill;
        playerController.playerActive = false;
        playerController.playerRb.velocity = new Vector2(0, 0); // report UI Ȱ��ȭ

        spawnManager.GetComponent<SpawnManager>().spawnActive = false;              //�����Ŵ��� OFF
        gameManager.enemyKillCount = 0;
        gameManager.DayBalance();
        gameManager.dayText.text = "Day: " + gameManager.dayCount;

        spriteOnCamera.ColorToDay();
    }//���� �� �� �۵���Ű�� �͵�

}
