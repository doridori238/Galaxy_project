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
    // ���������θ� ���� �ϱ⿡ ��������Ʈ�� ���� ���� �ʴ´� .. ���� ���� ������ �ʹ�!
}




 