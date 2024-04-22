using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpPotion : MonoBehaviour
{
    public List<Item> mpPotionitemData = new List<Item>();
    public Item basicMpPotionData = new Item();
    public Item goodMpPotionData = new Item();
    public Item strongMpPotionData = new Item();

    [SerializeField] ITEMDETAIL currentMpPotionItem;
    [SerializeField] LV_LIMIT currentMpPotionLv;

    void Start()
    {
        mpPotionitemData = DataLoad.instance.valuesList;

        foreach (Item item in mpPotionitemData)
        {
            if ((int)item.detail == 6 && (int)item.lvlimit == 1)
                basicMpPotionData = item;
            else if ((int)item.detail == 6 && (int)item.lvlimit == 5)
                goodMpPotionData = item;
            else if ((int)item.detail == 6 && (int)item.lvlimit == 10)
                strongMpPotionData = item;
            else
                continue;
        }



    }


}
