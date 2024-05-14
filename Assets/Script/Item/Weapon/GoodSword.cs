using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ComponentPattern;
using static InterfaceManager;

public class GoodSword : Weapon, IComponentable, ISendItemDataAble
{
    [SerializeField] public Item currentItem;

    private void Start()
    {
        currentItem = DataLoad.instance.valuesList[7];
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
