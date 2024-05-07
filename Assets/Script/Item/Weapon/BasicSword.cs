using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ComponentPattern;
using static InterfaceManager;
using static UnityEditor.Progress;

public class BasicSword : Weapon, IComponentable, ISendItemDataAble
{
    Item currentItem ;
    [SerializeField] int itemindex;
    [SerializeField] string itemname;
    [SerializeField] ITEMTYPE itemtype;
    [SerializeField] ITEMDETAIL detail;
    [SerializeField] LV_LIMIT lvlimit;
    [SerializeField] int option1;
    [SerializeField] int value1;
    [SerializeField] int option2;
    [SerializeField] int value2;
    [SerializeField] int option3;
    [SerializeField] int value3;
    [SerializeField] int option4;
    [SerializeField] int value4;

    Sprite currentSprite;


    private void Start()
    {
        //currentSprite = gameObject.GetComponent<Image>().sprite;
    }


    private void Update()
    {
        if (currentItem.itemname == null)
        {
            currentItem = ItemData.instance.basicweaponData;
            ItemInData();     
        }
        else
            return; 

    }





    public override void ItemInData()
    {
        itemindex = currentItem.itemindex;
        itemname = currentItem.itemname;
        itemtype = currentItem.itemtype;
        detail = currentItem.detail;
        lvlimit = currentItem.lvlimit;
        option1 = currentItem.option1;
        option2 = currentItem.option2;
        option3 = currentItem.option3;
        option4 = currentItem.option4;
        value1 = currentItem.value1;
        value2 = currentItem.value2;
        value3 = currentItem.value3;
        value4 = currentItem.value4;

    }

    public void Operation()
    {
        throw new System.NotImplementedException();
    }

    public Item OnSendItemDataAble(Item item)
    {
        item = currentItem;
       
        return item;
    }
    // 아이템으로만 리턴 하기에 스프라이트는 리턴 되지 않는다 .. 나는 같이 보내고 싶다!
}














    //public BasicSword(Item currentItem, int itemindex, string itemname, ITEMTYPE itemtype, ITEMDETAIL detail, LV_LIMIT lvlimit, int option1, int value1, int option2, int value2, int option3, int value3, int option4, int value4)
    //{
    //    itemindex = currentItem.itemindex;
    //    itemname = currentItem.itemname;
    //    itemtype = currentItem.itemtype;
    //    detail = currentItem.detail;
    //    lvlimit = currentItem.lvlimit;
    //    option1 = currentItem.option1;
    //    option2 = currentItem.option2;
    //    option3 = currentItem.option3;
    //    option4 = currentItem.option4;
    //    value1 = currentItem.value1;
    //    value2 = currentItem.value2;
    //    value3 = currentItem.value3;
    //    value4 = currentItem.value4;

    //}
 