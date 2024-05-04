using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public interface ISendItemDataAble
    {
        Item OnSendItemDataAble(Item item, Sprite sprite);
    }

    public interface IGetItemDataAble
    {
        void GetItemDataAble(ISendItemDataAble OnSendItemData);

    }


}
