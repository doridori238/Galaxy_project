using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ComponentPattern;
using static InterfaceManager;

public class StrongMpPotion : MpPotion, IComponentable
{

    [SerializeField] public Item currentItem;
    public ItemClass currentClass;

    private void Start()
    {
        currentItem = DataLoad.instance.valuesList[5];
        currentItem.sprite = GetComponent<SpriteRenderer>().sprite;
        currentClass = GetComponent<StrongMpPotion>();
    }


    public void Operation()
    {
        throw new System.NotImplementedException();
    }


    public override void ItemUse(Player player)
    {
        player.Mp += currentItem.value1;
    }



    public override ItemClass GetItemClass()
    {
        this.CurrentItem = currentItem;
        return this.ItemClassName = currentClass;
    }
}
