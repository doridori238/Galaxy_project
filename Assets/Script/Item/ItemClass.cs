using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ComponentPattern;
using static InterfaceManager;

public  class ItemClass : MonoBehaviour, ISendItemDataAble
{
    ItemClass itemClass;

    public ItemClass ItemClassName
    {
        get { return itemClass; }
        set { itemClass = value; }

    }

    Item currnetItem;

    public Item CurrentItem
    {
        get { return currnetItem; }
        set { currnetItem = value; }
    }


    public virtual Item GetItem()
    {
        throw new System.NotImplementedException();
    }


    public virtual ItemClass GetItemClass()
    {
        throw new System.NotImplementedException();
    }


    public virtual void ItemUse(Player player)
    {
       

    }


}
