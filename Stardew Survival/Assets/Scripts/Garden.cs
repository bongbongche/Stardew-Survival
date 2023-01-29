using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    [Header("�ٸ� ��ũ��Ʈ ����")]
    private GameManager gameManager;
    private PlayerController playerController;
    private MouseSelect mouseSelect;

    [Header("���� ���� ���� �� ��������Ʈ ����")]
    private int gardenMode; // 0: �ƹ��͵� ���� , seed1: 123, seed2: 456, seed3: 789
    private SpriteRenderer gardenSpriteRenderer;
    public Sprite[] gardenSprite;
    private BoxCollider2D gardenTouch;

    [Header("Garden�� �������ͽ�")]
    public int[] gardenPrice = new int[3]; // 3�ܰ��� ��ġ
    public int[] gardenMaxHpArr = new int[10]; // ���� �ִ� HP �迭

    private float gardenMaxHp; // ���� ���� �ִ� HP
    public float gardenPresentHp; // ���� ���� HP
    public bool getFertilizer;

    [Header("Garden�� HP�� ����")]
    public GameObject hpBar;
    public GameObject hpBarBackground;

    void Start()
    {
        getFertilizer = true;
        gardenMode = 0;
        transform.tag = "EmptyGarden";
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        mouseSelect = GameObject.Find("Player").transform.Find("Select").GetComponent<MouseSelect>();
        gardenSpriteRenderer = GetComponent<SpriteRenderer>();
        gardenSpriteRenderer.sprite = gardenSprite[gardenMode];
        gardenTouch = transform.GetChild(2).GetComponent<BoxCollider2D>();
        gardenTouch.enabled = false;
        hpBar = transform.GetChild(0).gameObject;
        hpBarBackground = transform.GetChild(1).gameObject;
        
    }

    private void Update()
    {
        if (gardenMode != 0 && gameManager.isDay && gardenPresentHp < gardenMaxHp)
            gardenPresentHp = gardenMaxHp;
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
        if(gardenMode == 0 || gameManager.isDay)
        {
            hpBar.GetComponent<SpriteRenderer>().enabled = false;
            hpBarBackground.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (!gameManager.isDay && !getFertilizer)
            getFertilizer = true;
        if (gameManager.isDay)
            gardenTouch.enabled = false;
        else if (!gameManager.isDay && gardenMode != 0)
            gardenTouch.enabled = true;


    }

    private void OnMouseDown()
    {
        // ���� ��, �÷��̾�� �Ÿ��� ����� ���� ����
        if (gameManager.isDay && mouseSelect.isActivated == true && getFertilizer == true)
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
                        getFertilizer = false;
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
    }//���� �÷��̾� ��� �ʿ� + ������ �۵�

    private void GardenChange()
    {
        gardenSpriteRenderer.sprite = gardenSprite[gardenMode];
        gardenMaxHp = gardenMaxHpArr[gardenMode];
        gardenPresentHp = gardenMaxHp;
        if (gardenMode == 0)
        {
            transform.tag = "EmptyGarden";
            gardenTouch.enabled = false;
        }
        else
        {
            transform.tag = "Garden";
            gardenTouch.enabled = true;
        }
    }



}
