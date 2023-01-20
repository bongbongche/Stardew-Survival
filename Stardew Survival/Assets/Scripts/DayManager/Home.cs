using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [Header("�ٸ� ��ũ��Ʈ�� ����")]
    private DayManager dayManager;
    private GameManager gameManager;

    public bool isClick;
    //Ŭ�� 1ȸ�� �۵��ǰ�

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
