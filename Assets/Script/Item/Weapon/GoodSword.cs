using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ComponentPattern;
using static InterfaceManager;

public class GoodSword : Weapon, IComponentable
{
    [SerializeField] public Item currentItem;
    public ItemClass currentClass;

    private void Start()
    {
        currentItem = DataLoad.instance.valuesList[7];
        currentItem.sprite = GetComponent<SpriteRenderer>().sprite;
        currentClass = GetComponent<GoodSword>();
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
