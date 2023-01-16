using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float currentPlayerHP;

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody2D playerRb;
    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // game manager�� ����Ǿ��ִ� �÷��̾� �ִ� ü���� ������
        currentPlayerHP = gameManagerScript.maxPlayerHP;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    // �÷��̾� �̵�
    private void PlayerMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        playerRb.velocity = new Vector2(horizontalInput * gameManagerScript.playerSpeed, playerRb.velocity.y);
        playerRb.velocity = new Vector2(playerRb.velocity.x, verticalInput * gameManagerScript.playerSpeed);
    }
}
