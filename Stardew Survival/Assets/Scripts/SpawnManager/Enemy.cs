using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Script Connect")]
    private GameManager gameManager;
    private DayManager dayManager;
    private PlayerController playerController;

    [Header("Enemy Status")]
    public float enemyPresentHp;
    public float enemyAttackCooltime;
    public float enemyAttackTimer;


    [Header("Enemy AI")]
    public List<GameObject> closeObjects;
    public GameObject closeObject;
    private int minidx;
    private float mindistance;
    private Rigidbody2D enemyRb;

    void Start()
    {
        dayManager = GameObject.Find("Day Manager").GetComponent<DayManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        enemyRb = GetComponent<Rigidbody2D>();
        enemyPresentHp = gameManager.enemyMaxHp;
        enemyAttackTimer = 0;
        enemyAttackCooltime = 0.1f;
        closeObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Garden"));
        if (closeObjects.Count == 0)
            closeObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        minidx = 0;
        mindistance = 1000.0f;
    }

    void Update()
    {
        minidx = 0;
        mindistance = 1000.0f;
        closeObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Garden"));
        if (closeObjects.Count == 0)
        {
            closeObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
            MoveEnemy(closeObjects[0].transform.position, gameManager.enemySpeed);
        }
        else
        {
            for (int i = 0; i < closeObjects.Count; i++)
            {
                if (mindistance > Vector2.Distance(closeObjects[i].transform.position, transform.position))
                {
                    mindistance = Vector2.Distance(closeObjects[i].transform.position, transform.position);
                    minidx = i;
                }
            }
            if (minidx < closeObjects.Count)
                MoveEnemy(closeObjects[minidx].transform.position, gameManager.enemySpeed);
        }





        if (enemyAttackTimer > 0.01f)
            enemyAttackTimer -= Time.deltaTime;

        if (enemyPresentHp <= 0)
        {
            gameManager.enemyKillCount++;
            if (gameManager.enemyKillCount % gameManager.getFertilizerPerKill == 0)
            {
                gameManager.playerFertilizer++;
            }
            Destroy(gameObject);
        }
        if (gameManager.isDay)
        {
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        // 플레이어가 밀면 velocity 값이 변하는 것을 방지 
        enemyRb.velocity = Vector2.zero;
    }


    public void MoveEnemy(Vector3 position, float speed)
    {
        Vector3 dir = (position - transform.position).normalized;
        transform.Translate(speed * dir * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Garden")
        {
            if (enemyAttackTimer <= 0.01f)
            {
                collision.gameObject.GetComponent<Garden>().gardenPresentHp -= gameManager.enemyDps / 10.0f;
                enemyAttackTimer = enemyAttackCooltime;
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            if (enemyAttackTimer <= 0.01f)
            {
                playerController.currentPlayerHP -= gameManager.enemyDps / 10.0f;
                enemyAttackTimer = enemyAttackCooltime;
            }
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Garden")
        {
            if (enemyAttackTimer <= 0.01f)
            {
                collision.gameObject.GetComponent<Garden>().gardenPresentHp -= gameManager.enemyDps / 10.0f;
                enemyAttackTimer = enemyAttackCooltime;
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            if (enemyAttackTimer <= 0.01f)
            {
                playerController.currentPlayerHP -= gameManager.enemyDps / 10.0f;
                enemyAttackTimer = enemyAttackCooltime;
            }
        }
    }
}
