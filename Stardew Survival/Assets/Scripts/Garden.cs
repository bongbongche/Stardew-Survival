using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    [Header("다른 스크립트 연결")]
    public GameManager gameManager;
    public PlayerController playerController;

    [Header("밭의 현재 상태 및 스프라이트 관리")]
    public int gardenMode; // 0: 아무것도 없음 , seed1: 123, seed2: 456, seed3: 789 
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
    }//여기 플레이어 모드 필요 + 낮에만 작동

}
