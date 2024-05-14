using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ComponentPattern;
using static InterfaceManager;

public class basicHpPotion : HpPotion, IComponentable, ISendItemDataAble
{

    [SerializeField] public Item currentItem;

    private void Start()
    {
        currentItem = DataLoad.instance.valuesList[0];
        currentItem.sprite = GetComponent<SpriteRenderer>().sprite;
    }


    public void Operation()
    {
        throw new System.NotImplementedException();
    }


    public void ItemUse(Player player)
    {
        player.Hp += currentItem.value1;
    }

    public Item GetItem()
    {
        return this.currentItem;
    }
}
