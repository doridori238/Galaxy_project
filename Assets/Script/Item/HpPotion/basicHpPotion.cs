using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ComponentPattern;
using static InterfaceManager;

public class BasicHpPotion : HpPotion, IComponentable
{

    [SerializeField] public Item currentItem;
    public ItemClass currentClass;
    Item nullitem;

    private void Start()
    {
        currentItem = DataLoad.instance.valuesList[0];
        currentItem.sprite = GetComponent<SpriteRenderer>().sprite;
        currentClass = GetComponent<BasicHpPotion>();
    }


    public void Operation()
    {
        throw new System.NotImplementedException();
    }


    public override void ItemUse(Player player)
    {
        player.Hp += currentItem.value1;
    }




    public override ItemClass GetItemClass()
    {
        this.CurrentItem = currentItem;
        return this.ItemClassName = currentClass;
    }
}
