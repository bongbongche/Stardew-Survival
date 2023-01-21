using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Script Connect")]
    private GameManager gameManager;
    private DayManager dayManager;

    [Header("Spawn Manage")]
    public GameObject enemy; // 
    private float spawnTimer;
    private float spawnRate;
    private int randArea; // 0,1,2,3
    private float randX;
    private float randY;
    private Vector3 randPosition;

    [Header("Spawn Switch")]
    public bool spawnActive;

    void Start()
    {
        spawnActive = false;
        spawnTimer = 0;
        dayManager = GameObject.Find("Day Manager").GetComponent<DayManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        SpawnTimerUpdate();
    }

    void Update()
    {
        if (spawnActive)
        {
            if (spawnTimer <= 0.1f)
            {
                spawnTimer = spawnRate;
                RandomSpawn();
            }
            else
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

    public void SpawnTimerUpdate()
    {
        spawnRate = gameManager.spawnRate;
    }

}