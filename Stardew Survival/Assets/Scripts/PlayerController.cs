using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float currentPlayerHP;

    private float horizontalInput;
    private float verticalInput;
    public Rigidbody2D playerRb;
    private GameManager gameManagerScript;
    // Start is called before the first frame update

    public int playerMode;
    // �� : 1 = ���� ( = �ȱ�), 2 = ���, 3 = ���� 1, 4 = ���� 2, 5 = ���� 3 ... / ~8 ���� �߰� ����
    // �� : 9 = ��

    public bool playerActive;
    // ���� �̿�� �Ǵ� ��� ��� �� ���� ��Ȳ�� �÷��̾� �������� ���ϵ���

    void Start()
    {
        playerActive = true;
        playerRb = GetComponent<Rigidbody2D>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // game manager�� ����Ǿ��ִ� �÷��̾� �ִ� ü���� ������
        currentPlayerHP = gameManagerScript.maxPlayerHP;

        playerMode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerActive)
        {
            PlayerMove();
            PlayerModeChange();
        } // ���� �̿�� �̵� X
    }

    // �÷��̾� �̵�
    private void PlayerMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        playerRb.velocity = new Vector2(horizontalInput * gameManagerScript.playerSpeed, playerRb.velocity.y);
        playerRb.velocity = new Vector2(playerRb.velocity.x, verticalInput * gameManagerScript.playerSpeed);
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
