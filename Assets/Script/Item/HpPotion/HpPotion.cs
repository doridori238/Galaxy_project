using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPotion : MonoBehaviour
{
    public List<Item> hpPotionitemData = new List<Item>();
    public Item basicHpPotionData = new Item();
    public Item goodHpPotionData = new Item();
    public Item strongHpPotionData = new Item();

    [SerializeField] ITEMDETAIL currentHpPotionItem;
    [SerializeField] LV_LIMIT currentHpPotionLv;
    void Start()
    {
        hpPotionitemData = DataLoad.instance.valuesList;

        foreach (Item item in hpPotionitemData)
        {
            if ((int)item.detail == 6 && (int)item.lvlimit == 1)
                basicHpPotionData = item;
            else if ((int)item.detail == 6 && (int)item.lvlimit == 5)
                goodHpPotionData = item;
            else if ((int)item.detail == 6 && (int)item.lvlimit == 10)
                strongHpPotionData = item;
            else
                continue;
        }
    }



}
