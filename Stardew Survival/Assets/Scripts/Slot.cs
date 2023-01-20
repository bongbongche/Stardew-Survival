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
    public int slotAmount;

    private BagManager bagManager;
    private GameManager gameManager;
    private TextMeshProUGUI slotAmoutText;
    // Start is called before the first frame update
    void Start()
    {
        bagManager = transform.parent.GetComponent<BagManager>();
        slotNumber = int.Parse(transform.Find("Slot Number").gameObject.GetComponent<TextMeshProUGUI>().text);
        if(slotNumber != 1)
        {
            slotAmoutText = transform.Find("Slot Amount").gameObject.GetComponent<TextMeshProUGUI>();
        }
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // 숫자 입력시 슬롯 활성화
        if(Input.GetKeyDown(slotNumber.ToString()))
        {
            button.onClick.Invoke();
        }

        // 슬롯 넘버에 따라 소모 아이템 업데이트 
        if (slotNumber == 2)
        {
            slotAmount = gameManager.playerFertilizer;
            slotAmoutText.text = "X" + slotAmount;
        }
        else if (slotNumber == 3)
        {
            slotAmount = gameManager.playerSeed1;
            slotAmoutText.text = "X" + slotAmount;
        }
        else if (slotNumber == 4)
        {
            slotAmount = gameManager.playerSeed2;
            slotAmoutText.text = "X" + slotAmount;
        }
        else if (slotNumber == 5)
        {
            slotAmount = gameManager.playerSeed3;
            slotAmoutText.text = "X" + slotAmount;
        }
    }

    // 마우스 클릭 or 숫자 입력시 슬롯 활성화
    public void clickMarking()
    {
        bagManager.preSelectedSlotNumber = bagManager.selectedSlotNumber;
        bagManager.selectedSlotNumber = slotNumber;
        bagManager.ActivateSlot(slotNumber);
    }

}
