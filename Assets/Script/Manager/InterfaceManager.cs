using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public interface ISendItemDataAble
    {
        Item GetItem();
    }

    public interface IGetItemDataAble
    {
        void GetItemDataAble(ISendItemDataAble OnSendItemData);

    }


}
