using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ITEMDETAIL
{
    WEAPON = 0,
    HP_POTION = 5,
    MP_POTION = 6
}

public enum ITEMTYPE
{
    CONSUMPTION = 1, // �Ҹ��� ������
    MOUNTING = 0     // ������ ������ 
}

public class ItemData : MonoBehaviour
{
    DataLoad dataLoad;

    void Start()
    {
        // int itemtype  = dataLoad.itemDic[0].itemtype;

    }
    //������ ������ enum�� ���缭 �������� ����� �ǵ��� �ϱ�
    // �κ��丮�� ���� ��� ������ ���� ��� 
    // WEAPON, detail = 5 , //enum�� int�� �ڽ�
    // ������ ��ü �����͸� ������ �з� �۾� ���ش�.
    // ����Ʈ�� ������� ��ųʸ�

    public void DivisionItemType(Dictionary<int,Item> itemDic) // ������ Ÿ�� �з� [ ���� �ϴ��� �Һ��ϴ���  �̰� üũ�ϱ� ���� �� ]
    { 
        

        //if (itemDic[i].itemtype == ITEMTYPE.CONSUMPTION)

        //    else
        //    itemDic[i].itemtype == ITEMTYPE.MOUNTING;
        //    return;
    }

    public void DivisionItemDetail(Dictionary<int, Item> itemDic) // ������ ������ �з�
    { 
       // ����ġ ������ ����
    
    }


    public void DivisionItem() // ������ �������� �з� 
    {
        //  �̰� �ϴ� �־�� ��� ������ ������..

    }


}

