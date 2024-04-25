using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSword : ItemClass
{
    Item currentItem;
    [SerializeField] Item itemindex;
    [SerializeField] Item itemname;
    [SerializeField] Item itemtype;
    [SerializeField] Item detail;
    [SerializeField] Item option1;
    [SerializeField] Item value1;
    [SerializeField] Item option2;
    [SerializeField] Item value2;
    [SerializeField] Item option3;
    [SerializeField] Item value3;
    [SerializeField] Item option4;
    [SerializeField] Item value4;

    public BasicSword()
     {



     }


    void Start()
    {
        currentItem = ItemData.instance.basicweaponData;
        Debug.Log(currentItem.itemname);

    }

 
}
