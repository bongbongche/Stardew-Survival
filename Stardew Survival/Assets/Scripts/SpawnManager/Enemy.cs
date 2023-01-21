using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Script Connect")]
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
        if (closeObjects.Count == 0)
            closeObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        MoveEnemy(closeObjects[0].transform.position, gameManager.enemySpeed);

        if (enemyPresentHp < 0)
        {
            Destroy(gameObject);
        }
        if (gameManager.isDay)
        {
            Destroy(gameObject);
        }

    }


    public void MoveEnemy(Vector3 position, float speed)
    {
        Vector3 dir = (position - transform.position).normalized;
        transform.Translate(speed * dir * Time.deltaTime);
    }

}
