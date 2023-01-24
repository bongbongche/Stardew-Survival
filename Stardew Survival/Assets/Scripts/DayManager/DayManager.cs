using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//밤낮 변경 시, 보여지고 사라지는 오브젝트 관리 스크립트
public class DayManager : MonoBehaviour
{
    [Header("밤낮음영")]
    public SpritesOnCamera spriteOnCamera; // 유니티에서 연결

    [Header("다른 스크립트들과 연결")]
    private PlayerController playerController;
    private GameManager gameManager;

    [Header("다른 시설들과 연결")]
    public GameObject home;
    public GameObject shop;
    public GameObject spawnManager;
    public GameObject reportUI;
    public GameObject playerHPBar;
    public GameObject playerInventory;
    public GameObject nightTimerBar;
    public TextMeshProUGUI reportFertilizer;

    [Header("플레이어와 연결")]
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

        shop.SetActive(false);                      //상점과 연결

        playerLight.SetActive(true);                //플레이어 주변 불 밝힘
        playerController.playerMode = 9;            //플레이어 모드 변경
        playerHPBar.SetActive(true);
        playerInventory.SetActive(false);
        nightTimerBar.SetActive(true);

        spawnManager.GetComponent<SpawnManager>().spawnActive = true;              //스폰매니저 ON

        spriteOnCamera.ColorToNight();
    }//밤이 될 때 작동시키는 것들

    public void TurnsToDay()
    {
        home.SetActive(true);

        shop.SetActive(true);                       // 상점과 연결

        playerLight.SetActive(false);               //플레이어 주변 불 끔
        playerController.playerMode = 1;            //플레이어 모드 변경
        playerController.currentPlayerHP = gameManager.maxPlayerHP; //플레이어 체력회복
        playerHPBar.SetActive(false);
        playerInventory.SetActive(true);
        nightTimerBar.SetActive(false);


        reportUI.SetActive(true);
        reportFertilizer.text = " "+ gameManager.enemyKillCount / gameManager.getFertilizerPerKill;
        playerController.playerActive = false;
        playerController.playerRb.velocity = new Vector2(0, 0); // report UI 활성화

        spawnManager.GetComponent<SpawnManager>().spawnActive = false;              //스폰매니저 OFF
        gameManager.enemyKillCount = 0;
        gameManager.DayBalance();
        gameManager.dayText.text = "Day: " + gameManager.dayCount;

        spriteOnCamera.ColorToDay();
    }//낮이 될 때 작동시키는 것들

}
