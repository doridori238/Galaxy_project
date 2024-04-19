using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<Item> weaponitemData = new List<Item>();
    public Item basicweaponData = new Item();
    public Item goodweaponData = new Item();
    public Item strongweaponData = new Item();

    [SerializeField] ITEMDETAIL currentWeaponItem;
    [SerializeField] LV_LIMIT currentWeaponLv;

    void Start()
    {
        weaponitemData = DataLoad.instance.valuesList;
        
        foreach (Item item in weaponitemData)
        {
            if (item.detail == 0 && (int)item.lvlimit == 1)
                basicweaponData = item;
            else if (item.detail == 0 && (int)item.lvlimit == 5)
                goodweaponData = item;
            else if (item.detail == 0 && (int)item.lvlimit == 10)
                strongweaponData = item;
            else
                continue;
        }

    }




}






        //WeaponDataInput(weaponitemData, basicweaponData, goodweaponData, strongweaponData);

    //public void WeaponDataInput(List<Item> weaponitemData, Item basicweaponData, Item goodweaponData, Item strongweaponData)
    //{
    //    foreach (Item item in weaponitemData)
    //    {
    //        Debug.Log(item.itemname);
    //        if (item.detail == 0 && (int)item.lvlimit == 1)
    //            basicweaponData = item;
    //        if (item.detail == 0 && (int)item.lvlimit == 5)
    //            goodweaponData = item;
    //        if (item.detail == 0 && (int)item.lvlimit == 10)
    //            strongweaponData = item;
    //        else
    //            continue;
    //    }

    //}