using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    [Header("�ٸ� ��ũ��Ʈ ����")]
    private GameManager gameManager;
    private PlayerController playerController;

    [Header("���� ���� ���� �� ��������Ʈ ����")]
    private int gardenMode; // 0: �ƹ��͵� ���� , seed1: 123, seed2: 456, seed3: 789
    private SpriteRenderer gardenSpriteRenderer;
    public Sprite[] gardenSprite;

    [Header("Garden�� �������ͽ�")]
    private int[] gardenPrice;      
    private float[] gardenMaxHpArr;
    //gameManager���� ������

    private float gardenMaxHp; // ���� ���� �ִ� HP
    public float gardenPresentHp; // ���� ���� HP

    void Start()
    {
        gardenMode = 0;
        gameObject.tag = "EmptyGarden";
        //���� �� �� �� ����

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        //��ũ��Ʈ ����

        gardenPrice = gameManager.gardenPrice;
        gardenMaxHpArr = gameManager.gardenMaxHpArr;
        //���ӸŴ����� �� ����

        gardenSpriteRenderer = GetComponent<SpriteRenderer>();
        gardenSpriteRenderer.sprite = gardenSprite[gardenMode];
        //���� ��������Ʈ
    }

    private void Update()
    {
        if (gardenPresentHp < gardenMaxHp && gameManager.isDay)
            gardenPresentHp = gardenMaxHp;
        // ���Ǹ� �ڵ�ȸ�� (�㿡 hp�� �ʿ��� ��)

        if (gardenPresentHp < 0 && !gameManager.isDay && gardenMode !=0 )
        {
            gardenMode = 0;
            GardenChange();
        }
        // �㿡 �Ĺ� Hp �� ���̸� ��� 0���� ���� (�� ���� ���ݴ�� �ƴϰ�, tag EmptyGarden ����)
    }

    private void OnMouseDown()
    {
        if (gameManager.isDay)
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
    }//���� �÷��̾� ��� �ʿ� + ������ �۵�

    private void GardenChange()
    {
        gardenSpriteRenderer.sprite = gardenSprite[gardenMode];
        gardenMaxHp = gardenMaxHpArr[gardenMode];
        gardenPresentHp = gardenMaxHp;

        if (gardenMode != 0)
            gameObject.tag = "Garden";
        else
            gameObject.tag = "EmptyGarden";

    }

}
