using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float currentPlayerHP;
    public WeaponParent weaponParent;
    public Rigidbody2D playerRb;
    public int weaponModeOnPlayerControl;

    private Vector2 movementInput, pointerInput, playerDirection;
    private GameManager gameManagerScript;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update

    public int playerMode;
    // 낮 : 1 = 괭이 ( = 팔기), 2 = 비료, 3 = 씨앗 1, 4 = 씨앗 2, 5 = 씨앗 3 ... / ~8 까지 추가 가능
    // 밤 : 9 = 밤

    public bool playerActive;
    // 상점 이용시 또는 비료 결산 시 등의 상황에 플레이어 움직이지 못하도록

    [SerializeField]
    private InputActionReference movement, attack, pointerPosition;
    
    // 마우스 클릭에 따라 공격
    private void OnEnable()
    {
        attack.action.performed += PerformAttack;
    }

    private void OnDisable()
    {
        attack.action.performed -= PerformAttack;
    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {
        if(gameManagerScript.isDay == false)
            weaponParent.Attack();
    }

    void Start()
    {
        playerActive = true;
        playerRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // game manager에 저장되어있는 플레이어 최대 체력을 가져옴
        currentPlayerHP = gameManagerScript.maxPlayerHP;
        
        weaponModeOnPlayerControl = 0;

        playerMode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // 낮일 때만 무기 활성화
        if (gameManagerScript.isDay == false)
        {
            weaponParent.gameObject.SetActive(true);
        }
        else if (gameManagerScript.isDay == true)
        {
            weaponParent.gameObject.SetActive(false);
        }

        // 마우스 포인터의 위치를 업데이트
        pointerInput = GetPointerInput();
        weaponParent.PointerPosition = pointerInput;

        playerDirection = (pointerInput - (Vector2)(transform.position)).normalized;

        // 마우스 방향에 따라 플레이어 스프라이트 변경
        if(playerDirection.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(playerDirection.x > 0)
        {
            spriteRenderer.flipX = true;
        }

        if (playerActive)
        {
            PlayerMove();
            PlayerModeChange();
        } // 상점 이용시 이동 X
        
    }

    // 플레이어 이동
    private void PlayerMove()
    {
        movementInput = movement.action.ReadValue<Vector2>().normalized;

        playerRb.velocity = new Vector2(movementInput.x * gameManagerScript.playerSpeed, playerRb.velocity.y);
        playerRb.velocity = new Vector2(playerRb.velocity.x, movementInput.y * gameManagerScript.playerSpeed);
    }

    // 마우스 위치 불러오기
    private Vector2 GetPointerInput()
    {
        Vector3 mousePosition = pointerPosition.action.ReadValue<Vector2>();
        mousePosition.z = Camera.main.nearClipPlane;

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }


    //플레이어 모드 변경 (낮에만 기능) , 밤에는 9번 고정
    private void PlayerModeChange()
    {
        if (gameManagerScript.isDay)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                playerMode = 1;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                playerMode = 2;
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                playerMode = 3;
            else if (Input.GetKeyDown(KeyCode.Alpha4))
                playerMode = 4;
            else if (Input.GetKeyDown(KeyCode.Alpha5))
                playerMode = 5;
        }
    }

}
