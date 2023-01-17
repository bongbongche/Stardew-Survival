using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�㳷 ���� ��, �������� ������� ������Ʈ ���� ��ũ��Ʈ
public class DayManager : MonoBehaviour
{
    [Header("�㳷����")]
    public SpritesOnCamera spriteOnCamera; // ����Ƽ���� ����

    [Header("�ٸ� �ü���� ����")]
    public GameObject home;
    public GameObject shop;

    [Header("�÷��̾�� ����")]
    public GameObject player;
    public GameObject playerLight;


    void Start()
    {
        playerLight = player.transform.Find("LightOnPlayer").gameObject;
        playerLight.SetActive(false);
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

        spriteOnCamera.ColorToNight();
    }//���� �� �� �۵���Ű�� �͵�

    public void TurnsToDay()
    {
        home.SetActive(true);
        home.GetComponent<Home>().isClick = false;  //���� ����

        shop.SetActive(true);                       // ������ ����

        playerLight.SetActive(false);               //�÷��̾� �ֺ� �� ��

        spriteOnCamera.ColorToDay();
    }//���� �� �� �۵���Ű�� �͵�

}
