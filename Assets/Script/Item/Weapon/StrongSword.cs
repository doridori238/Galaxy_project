using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static ComponentPattern;
using static InterfaceManager;

public class StrongSword : Weapon, IComponentable, ISendItemDataAble
{

    [SerializeField] public Item currentItem;

    private void Start()
    {
        currentItem = DataLoad.instance.valuesList[8];
        currentItem.sprite = GetComponent<SpriteRenderer>().sprite;
    }


    public void Operation()
    {
        throw new System.NotImplementedException();
    }


    public Item GetItem()
    {
        return this.currentItem;
    }

}
