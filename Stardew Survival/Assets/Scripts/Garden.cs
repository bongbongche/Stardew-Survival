using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    [Header("�ٸ� ��ũ��Ʈ ����")]
    public GameManager gameManager;
    public PlayerController playerController;

    [Header("���� ���� ���� �� ��������Ʈ ����")]
    public int gardenMode;  //0: �ƹ��͵� ���� , seed1: 123, seed2: 456, seed3: 789
    public int gardenHp;    //�� ���� �Ĺ��� HP
    public SpriteRenderer gardenSprite;
    public Sprite[] flowerSprite;

    [Header("��1�� �������ͽ�")]
    public int[] maxHpOfFlower1;
    public int priceOfFlower1;

    [Header("��2�� �������ͽ�")]
    public int[] maxHpOfFlower2;
    public int priceOfFlower2;

    [Header("��3�� �������ͽ�")]
    public int[] maxHpOfFlower3;
    public int priceOfFlower3;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gardenSprite = GetComponent<SpriteRenderer>();
        gardenSprite.sprite = flowerSprite[0];
    }

    //gardenSprite.sprite = flowerSprite[x]�� ���氡��
    private void OnMouseDown()
    {
        if (gameManager.isDay)
        {

        }
    }//���� �÷��̾� ��� �ʿ� + ������ �۵�


    //�ʿ��Ѱ� : player Active, player Mode
}
