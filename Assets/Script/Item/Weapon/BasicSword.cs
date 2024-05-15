using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;
using static ComponentPattern;
using static InterfaceManager;
using static UnityEditor.Progress;

public class BasicSword : Weapon, IComponentable
{
    [SerializeField] public Item currentItem;
    public ItemClass currentClass;

    private void Start()
    {
        currentItem = DataLoad.instance.valuesList[6];
        currentItem.sprite = GetComponent<SpriteRenderer>().sprite;
        currentClass = GetComponent<BasicSword>();
        
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
    // 아이템으로만 리턴 하기에 스프라이트는 리턴 되지 않는다 .. 나는 같이 보내고 싶다!
}




 