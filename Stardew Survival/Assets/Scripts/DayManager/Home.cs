using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [Header("다른 스크립트와 연결")]
    private DayManager dayManager;
    private GameManager gameManager;

    private void Awake()
    {
        dayManager = GameObject.Find("Day Manager").GetComponent<DayManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameManager.DayChange();
    }
}
