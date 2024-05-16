using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InterfaceManager;

public class InvenUi : Singleton<InvenUi>, IGetItemDataAble
{
    public Slot[] slots;
    ISendItemDataAble sendItemDataAble;
    
   

    public void AddItem(ISendItemDataAble OnSendItemData)
    {

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemClass1 == null)
            {
                slots[i].GetItemDataAble(OnSendItemData);
                Debug.Log("¤·¤¢¤·");
                return;
            }

        }

    }

    public void GetItemDataAble(ISendItemDataAble OnSendItemData)
    {
        sendItemDataAble = OnSendItemData;
        AddItem(sendItemDataAble);
    }

  
   
}
