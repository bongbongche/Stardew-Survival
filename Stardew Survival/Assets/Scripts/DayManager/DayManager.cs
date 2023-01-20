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
    public GameObject spawnManager;

    [Header("�÷��̾�� ����")]
    private GameObject player;
    public GameObject playerLight;


    void Start()
    {
        player = GameObject.Find("Player");
        playerLight.SetActive(false);
        playerController = player.GetComponent<PlayerController>();
        //spawnManager = GameObject.Find("Spawn Manager");
    }

    void Update()
    {
        
    }

    public void TurnsToNight()
    {
        home.SetActive(false);
        //home.GetComponent<Home>().isClick = false;  //���� ����

        shop.SetActive(false);                      //������ ����


        playerLight.SetActive(true);                //�÷��̾� �ֺ� �� ����
        playerController.playerMode = 9;            //�÷��̾� ��� ����

        spawnManager.SetActive(true);               //�����Ŵ��� �۵�

        spriteOnCamera.ColorToNight();
    }//���� �� �� �۵���Ű�� �͵�

    public void TurnsToDay()
    {
        home.SetActive(true);
        //home.GetComponent<Home>().isClick = false;  //���� ����

        shop.SetActive(true);                       // ������ ����

        playerLight.SetActive(false);               //�÷��̾� �ֺ� �� ��
        playerController.playerMode = 1;            //�÷��̾� ��� ����

        spawnManager.SetActive(false);               //�����Ŵ��� ����

        spriteOnCamera.ColorToDay();
    }//���� �� �� �۵���Ű�� �͵�

}
