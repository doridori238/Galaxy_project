using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using static InterfaceManager;

public class Weapon : MonoBehaviour
{
    public List<Item> weaponitemData = new List<Item>();
    public Item basicweaponData = new Item();
    public Item goodweaponData = new Item();
    public Item strongweaponData = new Item();

    [SerializeField] ITEMDETAIL currentWeaponItem = ITEMDETAIL.WEAPON;
    [SerializeField] LV_LIMIT currentWeaponLv = LV_LIMIT.ONE_LV;

   
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





