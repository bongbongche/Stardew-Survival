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
        if(selectedSlotNumber != preSelectedSlotNumber)
        {
            DeactivateSlot(preSelectedSlotNumber);
            ActivateSlot(selectedSlotNumber);
        }
    }

    public void ActivateSlot(int slotNumber)
    {
        colorBlock.normalColor = colorBlock.selectedColor = Color.black;
        slots[slotNumber - 1].colors = colorBlock;
    }

    public void DeactivateSlot(int slotNumber)
    {
        colorBlock = ColorBlock.defaultColorBlock;
        slots[slotNumber - 1].colors = colorBlock;
    }
}
