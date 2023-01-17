using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    [Header("다른 스크립트 연결")]
    public GameManager gameManager;
    public PlayerController playerController;

    [Header("밭의 현재 상태 및 스프라이트 관리")]
    public int gardenMode;  //0: 아무것도 없음 , seed1: 123, seed2: 456, seed3: 789
    public int gardenHp;    //밭 현재 식물의 HP
    public SpriteRenderer gardenSprite;
    public Sprite[] flowerSprite;

    [Header("꽃1의 스테이터스")]
    public int[] maxHpOfFlower1;
    public int priceOfFlower1;

    [Header("꽃2의 스테이터스")]
    public int[] maxHpOfFlower2;
    public int priceOfFlower2;

    [Header("꽃3의 스테이터스")]
    public int[] maxHpOfFlower3;
    public int priceOfFlower3;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gardenSprite = GetComponent<SpriteRenderer>();
        gardenSprite.sprite = flowerSprite[0];
    }

    //gardenSprite.sprite = flowerSprite[x]로 변경가능
    private void OnMouseDown()
    {
        if (gameManager.isDay)
        {

        }
    }//여기 플레이어 모드 필요 + 낮에만 작동


    //필요한거 : player Active, player Mode
}
