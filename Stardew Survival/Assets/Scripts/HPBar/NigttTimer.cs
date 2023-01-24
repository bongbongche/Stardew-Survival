using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NigttTimer : MonoBehaviour
{
    public Slider nightTimerBar;
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        nightTimerBar.value = gameManager.nightTimer / gameManager.nightTime;
    }
}
