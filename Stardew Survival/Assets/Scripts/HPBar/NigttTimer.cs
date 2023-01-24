using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NigttTimer : MonoBehaviour
{
    public Slider hpbar;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpbar.value = gameManager.nightTimer / gameManager.nightTime;
    }
}
