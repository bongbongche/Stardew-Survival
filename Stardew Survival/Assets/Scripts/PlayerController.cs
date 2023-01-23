using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float currentPlayerHP;
    public Rigidbody2D playerRb;

    private Vector2 movementInput, pointerInput, playerDirection;
    private WeaponParent weaponParent;
    private GameManager gameManagerScript;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update

    public int playerMode;
    // �� : 1 = ���� ( = �ȱ�), 2 = ���, 3 = ���� 1, 4 = ���� 2, 5 = ���� 3 ... / ~8 ���� �߰� ����
    // �� : 9 = ��

    public bool playerActive;
    // ���� �̿�� �Ǵ� ��� ��� �� ���� ��Ȳ�� �÷��̾� �������� ���ϵ���

    [SerializeField]
    private InputActionReference movement, attack, pointerPosition;
    
    // ���콺 Ŭ���� ���� ����
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
        weaponParent.Attack();
    }

    void Start()
    {
        playerActive = true;
        playerRb = GetComponent<Rigidbody2D>();
        weaponParent = GetComponentInChildren<WeaponParent>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // game manager�� ����Ǿ��ִ� �÷��̾� �ִ� ü���� ������
        currentPlayerHP = gameManagerScript.maxPlayerHP;

        playerMode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 �������� ��ġ�� ������Ʈ
        pointerInput = GetPointerInput();
        weaponParent.PointerPosition = pointerInput;

        playerDirection = (pointerInput - (Vector2)(transform.position)).normalized;
        Vector2 scale = transform.localScale;
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
        } // ���� �̿�� �̵� X
    }

    // �÷��̾� �̵�
    private void PlayerMove()
    {
        movementInput = movement.action.ReadValue<Vector2>().normalized;

        playerRb.velocity = new Vector2(movementInput.x * gameManagerScript.playerSpeed, playerRb.velocity.y);
        playerRb.velocity = new Vector2(playerRb.velocity.x, movementInput.y * gameManagerScript.playerSpeed);
    }

    // ���콺 ��ġ �ҷ�����
    private Vector2 GetPointerInput()
    {
        Vector3 mousePosition = pointerPosition.action.ReadValue<Vector2>();
        mousePosition.z = Camera.main.nearClipPlane;

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }


    //�÷��̾� ��� ���� (������ ���) , �㿡�� 9�� ����
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
