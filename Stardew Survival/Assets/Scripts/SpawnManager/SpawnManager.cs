using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("asd")]
    private GameManager gameManager;
    private DayManager dayManager;

    [Header("abs")]
    public GameObject enemy; // 
    private float spawnTimer;
    private int randArea; // 0,1,2,3
    private float randX;
    private float randY;
    private Vector3 randPosition;

    void Start()
    {
        spawnTimer = 0;
        dayManager = GameObject.Find("Day Manager").GetComponent<DayManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (spawnTimer <= 0.1f)
        {
            //spawnTimer = gameManager.spawnRate;
            RandomSpawn();
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    private void RandomSpawn()
    {
        randArea = Random.Range(0, 3); 
        switch (randArea)
        {
            case 0:
                randX = Random.Range(-10, 10);
                randY = Random.Range(6, 8);
                break;
            case 1:
                randX = Random.Range(10, 12);
                randY = Random.Range(-8, 8);
                break;
            case 2:
                randX = Random.Range(-10, 10);
                randY = Random.Range(-6, -8);
                break;
            case 3:
                randX = Random.Range(-12, -10);
                randY = Random.Range(-8, 8);
                break;
        }
        randPosition = new Vector3(randX, randY, 0);
        Instantiate(enemy, randPosition, Quaternion.identity);
    }


}