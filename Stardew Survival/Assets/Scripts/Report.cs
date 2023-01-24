using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report : MonoBehaviour
{
    public GameObject reportUI;
    private GameObject player;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ReportExit()
    {
        reportUI.SetActive(false);
        playerController.playerActive = true;
    }
}
