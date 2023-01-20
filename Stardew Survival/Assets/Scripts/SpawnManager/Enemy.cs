using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("다른 스크립트와 연결")]
    private GameManager gameManager;
    private DayManager dayManager;

    [Header("Enemy Status")]
    public float enemyPresentHp;

    [Header("Enemy AI")]
    public List<GameObject> closeObjects;

    void Start()
    {
        dayManager = GameObject.Find("Day Manager").GetComponent<DayManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemyPresentHp = gameManager.enemyMaxHp;
    }

    void Update()
    {
        closeObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Garden"));
        if (closeObjects.Count==0)
            closeObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        MoveEnemy(closeObjects[0].transform.position, gameManager.enemySpeed);



        if (enemyPresentHp < 0)
        {
            Destroy(gameObject);
            // + 비료 드랍
        }
        if (gameManager.isDay)
        {
            Destroy(gameObject);
            // 비료 드랍...?
        }

    }

    //hp 닳게, 식물 우선, 알아서 찾아가게

    public void MoveEnemy(Vector3 position, float speed)
    {
        Vector3 dir = (position - transform.position).normalized;
        transform.Translate(speed * dir * Time.deltaTime);
    }// 이후 무기로 밀쳐낼때도 사용 가능 할 듯.
    //밀쳐낼때는 포지션에 플레이어 둘 것
    //지금은 배열 [0]번 찾기

}