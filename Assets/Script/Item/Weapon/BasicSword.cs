using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;
using static ComponentPattern;
using static InterfaceManager;
using static UnityEditor.Progress;

public class BasicSword : Weapon, IComponentable, ISendItemDataAble
{
    [SerializeField] public Item currentItem;

    private void Start()
    {
        currentItem = DataLoad.instance.valuesList[6];
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
    // ���������θ� ���� �ϱ⿡ ��������Ʈ�� ���� ���� �ʴ´� .. ���� ���� ������ �ʹ�!
}




 