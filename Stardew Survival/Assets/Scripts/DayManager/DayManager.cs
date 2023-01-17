using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//밤낮 변경 시, 보여지고 사라지는 오브젝트 관리 스크립트
public class DayManager : MonoBehaviour
{
    [Header("밤낮음영")]
    public SpritesOnCamera spriteOnCamera; // 유니티에서 연결

    [Header("다른 시설들과 연결")]
    public GameObject home;
    public GameObject shop;

    [Header("플레이어와 연결")]
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
        home.GetComponent<Home>().isClick = false;  //집과 연결

        shop.SetActive(false);                      //상점과 연결


        playerLight.SetActive(true);                //플레이어 주변 불 밝힘

        spriteOnCamera.ColorToNight();
    }//밤이 될 때 작동시키는 것들

    public void TurnsToDay()
    {
        home.SetActive(true);
        home.GetComponent<Home>().isClick = false;  //집과 연결

        shop.SetActive(true);                       // 상점과 연결

        playerLight.SetActive(false);               //플레이어 주변 불 끔

        spriteOnCamera.ColorToDay();
    }//낮이 될 때 작동시키는 것들

}
