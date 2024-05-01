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
    //        // 무기item
    //        if ((int)itemData[i].detail == 0 && (int)itemData[i].lvlimit == 1)
    //            basicweaponData = itemData[i];
    //        if ((int)itemData[i].detail == 0 && (int)itemData[i].lvlimit == 5)
    //            goodweaponData = itemData[i];
    //        if ((int)itemData[i].detail == 0 && (int)itemData[i].lvlimit == 10)
    //            strongweaponData = itemData[i];
    //        // hp포션 
    //        if ((int)itemData[i].detail == 5 && (int)itemData[i].lvlimit == 1)
    //            basicHppotion = itemData[i];
    //        if ((int)itemData[i].detail == 5 && (int)itemData[i].lvlimit == 5)
    //            goodHppotion = itemData[i];
    //        if ((int)itemData[i].detail == 5 && (int)itemData[i].lvlimit == 10)
    //            strongHppotion = itemData[i];
    //        //mp포션
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
            // 무기item
            if ((int)itemData[i].detail == 0 && (int)itemData[i].lvlimit == 1)
                basicweaponData = itemData[i];
            if ((int)itemData[i].detail == 0 && (int)itemData[i].lvlimit == 5)
                goodweaponData = itemData[i];
            if ((int)itemData[i].detail == 0 && (int)itemData[i].lvlimit == 10)
                strongweaponData = itemData[i];
            // hp포션 
            if ((int)itemData[i].detail == 5 && (int)itemData[i].lvlimit == 1)
                basicHppotion = itemData[i];
            if ((int)itemData[i].detail == 5 && (int)itemData[i].lvlimit == 5)
                goodHppotion = itemData[i];
            if ((int)itemData[i].detail == 5 && (int)itemData[i].lvlimit == 10)
                strongHppotion = itemData[i];
            //mp포션
            if ((int)itemData[i].detail == 6 && (int)itemData[i].lvlimit == 1)
                basicMppotion = itemData[i];
            if ((int)itemData[i].detail == 6 && (int)itemData[i].lvlimit == 5)
                goodMppotion = itemData[i];
            if ((int)itemData[i].detail == 6 && (int)itemData[i].lvlimit == 10)
                strongMppotion = itemData[i];
        }



        Debug.Log(basicweaponData.itemname);


    }

    //아이템 디테일 enum에 맞춰서 아이템이 디버깅 되도록 하기
    // 인벤토리와 무기 장비 연결을 위한 토대 
    // WEAPON, detail = 5 , //enum을 int로 박싱
    // 아이템 전체 데이터를 가지고 분류 작업 해준다.

 






}

