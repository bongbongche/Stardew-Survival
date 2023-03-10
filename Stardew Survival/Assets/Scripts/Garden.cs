using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    [Header("다른 스크립트 연결")]
    private GameManager gameManager;
    private PlayerController playerController;
    private MouseSelect mouseSelect;

    [Header("밭의 현재 상태 및 스프라이트 관리")]
    private int gardenMode; // 0: 아무것도 없음 , seed1: 123, seed2: 456, seed3: 789
    private SpriteRenderer gardenSpriteRenderer;
    public Sprite[] gardenSprite;

    [Header("Garden의 스테이터스")]
    public int[] gardenPrice = new int[3]; // 3단계의 가치
    public int[] gardenMaxHpArr = new int[10]; // 밭의 최대 HP 배열

    private float gardenMaxHp; // 밭의 현재 최대 HP
    public float gardenPresentHp; // 밭의 현재 HP

    [Header("Garden의 HP바 구현")]
    public GameObject hpBar;
    public GameObject hpBarBackground;

    void Start()
    {
        gardenMode = 0;
        transform.tag = "EmptyGarden";
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        mouseSelect = GameObject.Find("Player").transform.Find("Select").GetComponent<MouseSelect>();
        gardenSpriteRenderer = GetComponent<SpriteRenderer>();
        gardenSpriteRenderer.sprite = gardenSprite[gardenMode];
        
        hpBar = transform.GetChild(0).gameObject;
        hpBarBackground = transform.GetChild(1).gameObject;
    }

    private void Update()
    {
        if (gardenMode != 0)
        {
            if (gardenPresentHp < gardenMaxHp && !gameManager.isDay)
            {
                hpBar.GetComponent<SpriteRenderer>().enabled = true;
                hpBarBackground.GetComponent<SpriteRenderer>().enabled = true;
                hpBar.transform.localScale = new Vector2 (0.8f * gardenPresentHp / gardenMaxHp, 0.15f);
                hpBar.transform.position = hpBarBackground.transform.position - new Vector3(0.4f - (0.8f * gardenPresentHp / gardenMaxHp)/2, 0,0);
            }
            if (gardenPresentHp <= 0)
            {
                gardenMode = 0;
                GardenChange();
            }      
        }

        if(gardenMode == 0)
        {
            hpBar.GetComponent<SpriteRenderer>().enabled = false;
            hpBarBackground.GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    private void OnMouseDown()
    {
        // 낮일 때, 플레이어와 거리가 가까울 때만 가능
        if (gameManager.isDay && mouseSelect.isActivated == true)
        {
            switch(playerController.playerMode)
            {
                case 1:
                    if (gardenMode != 0 && gardenMode % 3 == 0)
                    { 
                        gameManager.playerMoney += gardenPrice[gardenMode / 3 - 1];
                        gardenMode = 0;
                        GardenChange();
                    }
                    break;
                case 2:
                    if ((gardenMode % 3 == 1 || gardenMode % 3 == 2) && gameManager.playerFertilizer > 0)
                    {
                        gardenMode++;
                        gameManager.playerFertilizer--;
                        GardenChange();
                    }
                    break;
                case 3:
                    if (gardenMode == 0 && gameManager.playerSeed1 >0)
                    {
                        gardenMode = 1;
                        gameManager.playerSeed1--;
                        GardenChange();
                    }
                    break;
                case 4:
                    if (gardenMode == 0 && gameManager.playerSeed2 > 0)
                    {
                        gardenMode = 4;
                        gameManager.playerSeed2--;
                        GardenChange();
                    }
                    break;
                case 5:
                    if (gardenMode == 0 && gameManager.playerSeed3 > 0)
                    {
                        gardenMode = 7;
                        gameManager.playerSeed3--;
                        GardenChange();
                    }
                    break;
            }
        }
    }//여기 플레이어 모드 필요 + 낮에만 작동

    private void GardenChange()
    {
        gardenSpriteRenderer.sprite = gardenSprite[gardenMode];
        gardenMaxHp = gardenMaxHpArr[gardenMode];
        gardenPresentHp = gardenMaxHp;
        if (gardenMode == 0)
            transform.tag = "EmptyGarden";
        else
            transform.tag = "Garden";
    }



}
