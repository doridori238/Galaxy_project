using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;




public class ItemData : Singleton<ItemData>
{
    public List<Item> itemData = new List<Item>();
    public Item basicweaponData;
    public Item goodweaponData;
    public Item strongweaponData;

    public Item basicMppotion;
    public Item goodMppotion;
    public Item strongMppotion;

    public Item basicHppotion;
    public Item goodHppotion;
    public Item strongHppotion;




    //private void OnEnable()
    //{
    //    itemData = DataLoad.instance.valuesList;
    //    if (itemData == null)
    //        return;


    //    for (int i = 0; i < itemData.Count; i++)
    //    {
    //        // ����item
    //        if ((int)itemData[i].detail == 0 && (int)itemData[i].lvlimit == 1)
    //            basicweaponData = itemData[i];
    //        if ((int)itemData[i].detail == 0 && (int)itemData[i].lvlimit == 5)
    //            goodweaponData = itemData[i];
    //        if ((int)itemData[i].detail == 0 && (int)itemData[i].lvlimit == 10)
    //            strongweaponData = itemData[i];
    //        // hp���� 
    //        if ((int)itemData[i].detail == 5 && (int)itemData[i].lvlimit == 1)
    //            basicHppotion = itemData[i];
    //        if ((int)itemData[i].detail == 5 && (int)itemData[i].lvlimit == 5)
    //            goodHppotion = itemData[i];
    //        if ((int)itemData[i].detail == 5 && (int)itemData[i].lvlimit == 10)
    //            strongHppotion = itemData[i];
    //        //mp����
    //        if ((int)itemData[i].detail == 6 && (int)itemData[i].lvlimit == 1)
    //            basicMppotion = itemData[i];
    //        if ((int)itemData[i].detail == 6 && (int)itemData[i].lvlimit == 5)
    //            goodMppotion = itemData[i];
    //        if ((int)itemData[i].detail == 6 && (int)itemData[i].lvlimit == 10)
    //            strongMppotion = itemData[i];
    //    }



    //}




    void Start()
    {
        itemData = DataLoad.instance.valuesList;
        if (itemData == null)
            return;


        for (int i = 0; i < itemData.Count; i++)
        {
            // ����item
            if ((int)itemData[i].detail == 0 && (int)itemData[i].lvlimit == 1)
                basicweaponData = itemData[i];
            if ((int)itemData[i].detail == 0 && (int)itemData[i].lvlimit == 5)
                goodweaponData = itemData[i];
            if ((int)itemData[i].detail == 0 && (int)itemData[i].lvlimit == 10)
                strongweaponData = itemData[i];
            // hp���� 
            if ((int)itemData[i].detail == 5 && (int)itemData[i].lvlimit == 1)
                basicHppotion = itemData[i];
            if ((int)itemData[i].detail == 5 && (int)itemData[i].lvlimit == 5)
                goodHppotion = itemData[i];
            if ((int)itemData[i].detail == 5 && (int)itemData[i].lvlimit == 10)
                strongHppotion = itemData[i];
            //mp����
            if ((int)itemData[i].detail == 6 && (int)itemData[i].lvlimit == 1)
                basicMppotion = itemData[i];
            if ((int)itemData[i].detail == 6 && (int)itemData[i].lvlimit == 5)
                goodMppotion = itemData[i];
            if ((int)itemData[i].detail == 6 && (int)itemData[i].lvlimit == 10)
                strongMppotion = itemData[i];
        }



        Debug.Log(basicweaponData.itemname);


    }

    //������ ������ enum�� ���缭 �������� ����� �ǵ��� �ϱ�
    // �κ��丮�� ���� ��� ������ ���� ��� 
    // WEAPON, detail = 5 , //enum�� int�� �ڽ�
    // ������ ��ü �����͸� ������ �з� �۾� ���ش�.

 






}

