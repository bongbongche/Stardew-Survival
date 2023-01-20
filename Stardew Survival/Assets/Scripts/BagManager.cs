using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{
    public int selectedSlotNumber;
    public int preSelectedSlotNumber;
    public Button[] slots;

    private ColorBlock colorBlock;

    // Start is called before the first frame update
    void Start()
    {
        selectedSlotNumber = preSelectedSlotNumber = 1;
        colorBlock = ColorBlock.defaultColorBlock;
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어가 새로운 슬롯을 선택하면 이전 슬롯은 비활성화, 현재 선택 슬롯은 활성화
        if(selectedSlotNumber != preSelectedSlotNumber)
        {
            DeactivateSlot(preSelectedSlotNumber);
            ActivateSlot(selectedSlotNumber);
        }
    }

    // 슬롯 활성화
    public void ActivateSlot(int slotNumber)
    {
        colorBlock.normalColor = colorBlock.selectedColor = Color.black;
        slots[slotNumber - 1].colors = colorBlock;
    }

    // 슬롯 비활성화
    public void DeactivateSlot(int slotNumber)
    {
        colorBlock = ColorBlock.defaultColorBlock;
        slots[slotNumber - 1].colors = colorBlock;
    }
}
