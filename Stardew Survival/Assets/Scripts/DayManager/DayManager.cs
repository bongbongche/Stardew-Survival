using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�㳷 ���� ��, �������� ������� ������Ʈ ���� ��ũ��Ʈ
public class DayManager : MonoBehaviour
{
    [Header("�㳷����")]
    public SpritesOnCamera spriteOnCamera; // ����Ƽ���� ����

    [Header("�ٸ� ��ũ��Ʈ��� ����")]
    private PlayerController playerController;

    [Header("�ٸ� �ü���� ����")]
    public GameObject home;
    public GameObject shop;

    [Header("�÷��̾�� ����")]
    private GameObject player;
    public GameObject playerLight;


    void Start()
    {
        player = GameObject.Find("Player");
        playerLight.SetActive(false);
        playerController = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        
    }

    public void TurnsToNight()
    {
        home.SetActive(false);
        home.GetComponent<Home>().isClick = false;  //���� ����

        shop.SetActive(false);                      //������ ����


        playerLight.SetActive(true);                //�÷��̾� �ֺ� �� ����
        playerController.playerMode = 9;            //�÷��̾� ��� ����

        spriteOnCamera.ColorToNight();
    }//���� �� �� �۵���Ű�� �͵�

    public void TurnsToDay()
    {
        home.SetActive(true);
        home.GetComponent<Home>().isClick = false;  //���� ����

        shop.SetActive(true);                       // ������ ����

        playerLight.SetActive(false);               //�÷��̾� �ֺ� �� ��
        playerController.playerMode = 1;            //�÷��̾� ��� ����

        spriteOnCamera.ColorToDay();
    }//���� �� �� �۵���Ű�� �͵�

}
