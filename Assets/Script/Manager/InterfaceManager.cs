using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
   
    public interface ISendItemDataAble
    {
        ItemClass GetItemClass();
    }

    public interface IGetItemDataAble
    {
        void GetItemDataAble(ISendItemDataAble OnSendItemData);

    }


}
