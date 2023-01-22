using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [Header("UI Connect")]
    public GameObject shopUi;
    public TextMeshProUGUI money;
    public TextMeshProUGUI seedprice1;
    public TextMeshProUGUI seedprice2;
    public TextMeshProUGUI seedprice3;


    [Header("Script Connect")]
    private GameManager gameManager;
    private PlayerController playerController;
    public GameObject warning;
    private float warningTimer;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        warningTimer = 0;
        shopUi.SetActive(false);
        seedprice1.text = "Price: " + gameManager.sellSeedPrice[0];
        seedprice2.text = "Price: " + gameManager.sellSeedPrice[1];
        seedprice3.text = "Price: " + gameManager.sellSeedPrice[2];
    }

    private void Update()
    {
        if (warningTimer >= 0.1f)
        {
            warning.SetActive(true);
            warningTimer -= Time.deltaTime;
        }
        else if(warningTimer != 0)
        {
            warning.SetActive(false);
            warningTimer = 0;
        }
        money.text = "$: " + gameManager.playerMoney;

    }

    private void OnMouseDown()
    {
        shopUi.SetActive(true);
        playerController.playerActive = false;
        playerController.playerRb.velocity = new Vector2 (0,0);
    }

    public void BuySeed1()
    {
        if (gameManager.playerMoney >= gameManager.sellSeedPrice[0])
        {
            gameManager.playerMoney -= gameManager.sellSeedPrice[0];
            gameManager.playerSeed1++;
        }
        else
            warningTimer = 0.7f;
    }
    public void BuySeed2()
    {
        if (gameManager.playerMoney >= gameManager.sellSeedPrice[1])
        {
            gameManager.playerMoney -= gameManager.sellSeedPrice[1];
            gameManager.playerSeed2++;
        }
        else
            warningTimer = 0.7f;
    }
    public void BuySeed3()
    {
        if (gameManager.playerMoney >= gameManager.sellSeedPrice[2])
        {
            gameManager.playerMoney -= gameManager.sellSeedPrice[2];
            gameManager.playerSeed3++;
        }
        else
            warningTimer = 0.7f;
    }

    public void ShopExit()
    {
        shopUi.SetActive(false);
        playerController.playerActive = true;
    }

}
