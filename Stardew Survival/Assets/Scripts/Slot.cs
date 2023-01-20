using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Button button;
    public int slotNumber;

    private BagManager bagManager;
    // Start is called before the first frame update
    void Start()
    {
        bagManager = transform.parent.GetComponent<BagManager>();
        slotNumber = int.Parse(transform.Find("Slot Number").gameObject.GetComponent<TextMeshProUGUI>().text);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(slotNumber.ToString()))
        {
            button.onClick.Invoke();
        }
    }

    public void clickMarking()
    {
        bagManager.preSelectedSlotNumber = bagManager.selectedSlotNumber;
        bagManager.selectedSlotNumber = slotNumber;
        bagManager.ActivateSlot(slotNumber);
    }

}
