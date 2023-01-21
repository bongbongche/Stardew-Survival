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

    [Header("Garden�� �������ͽ�")]
    public int[] gardenPrice = new int[3]; // 3�ܰ��� ��ġ
    public int[] gardenMaxHpArr = new int[10]; // ���� �ִ� HP �迭

    private int gardenMaxHp; // ���� ���� �ִ� HP
    public int gardenPresentHp; // ���� ���� HP

    void Start()
    {
        gardenMode = 0;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        mouseSelect = GameObject.Find("Player").transform.Find("Select").GetComponent<MouseSelect>();
        gardenSpriteRenderer = GetComponent<SpriteRenderer>();
        gardenSpriteRenderer.sprite = gardenSprite[gardenMode];
    }


    private void OnMouseDown()
    {
        // ���� ��, �÷��̾�� �Ÿ��� ����� ���� ����
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
    }//���� �÷��̾� ��� �ʿ� + ������ �۵�

    private void GardenChange()
    {
        gardenSpriteRenderer.sprite = gardenSprite[gardenMode];
        gardenMaxHp = gardenMaxHpArr[gardenMode];
        gardenPresentHp = gardenMaxHp;
    }

}
