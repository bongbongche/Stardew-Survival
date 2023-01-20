using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [Header("다른 스크립트와 연결")]
    private DayManager dayManager;
    private GameManager gameManager;

    public bool isClick;
    //클릭 1회만 작동되게

    private void Awake()
    {
        isClick = false;
        dayManager = GameObject.Find("Day Manager").GetComponent<DayManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!isClick)
        {
            gameManager.DayChange();
            isClick = true;
        }
    }
}
