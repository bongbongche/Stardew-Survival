using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    [Header("�ٸ� ��ũ��Ʈ ����")]
    public GameManager gameManager;
    public PlayerController playerController;

    [Header("���� ���� ���� �� ��������Ʈ ����")]
    public int gardenMode; // 0: �ƹ��͵� ���� , seed1: 123, seed2: 456, seed3: 789 
    public Sprite[] gardenSprite;


    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    private void OnMouseDown()
    {
        if (gameManager.isDay)
        {

        }
    }//���� �÷��̾� ��� �ʿ� + ������ �۵�

}
