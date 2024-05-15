using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ComponentPattern;
using static InterfaceManager;

public class StrongHppotion : HpPotion, IComponentable
{

    [SerializeField] public Item currentItem;
    public ItemClass currentClass;

    private void Start()
    {
        currentItem = DataLoad.instance.valuesList[2];
        currentItem.sprite = GetComponent<SpriteRenderer>().sprite;
        currentClass = GetComponent<StrongHppotion>();
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
