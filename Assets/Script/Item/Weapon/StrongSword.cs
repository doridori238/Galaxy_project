using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static ComponentPattern;
using static InterfaceManager;

public class StrongSword : Weapon, IComponentable
{

    [SerializeField] public Item currentItem;
    public ItemClass currentClass;
    Item nullitem;
    private void Start()
    {
        currentItem = DataLoad.instance.valuesList[8];
        currentItem.sprite = GetComponent<SpriteRenderer>().sprite;
        currentClass = GetComponent<StrongSword>();
    }


    public void Operation()
    {
        throw new System.NotImplementedException();
    }


    public override void ItemUse(Player player)
    {
        player.Crt += currentItem.value1;

    }

   
    public override ItemClass GetItemClass()
    {
        this.CurrentItem = currentItem;
        return this.ItemClassName = currentClass;
    }

}
