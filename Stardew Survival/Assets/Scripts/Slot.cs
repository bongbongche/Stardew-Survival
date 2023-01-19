using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Button button;
    public string slotNumber;
    // Start is called before the first frame update
    void Start()
    {
        slotNumber = transform.Find("Slot Number").gameObject.GetComponent<TextMeshProUGUI>().text;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(slotNumber))
        {
            button.onClick.Invoke();
        }
    }

    public void sayHi()
    {
        Debug.Log(transform.Find("Slot Number").gameObject.GetComponent<TextMeshProUGUI>().text);
    }
}
