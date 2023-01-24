using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPBar : MonoBehaviour
{
    public Slider hpbar;
    public PlayerController playerController; // 연결 필요
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hpbar.value = playerController.currentPlayerHP / gameManager.maxPlayerHP;
    }
}


