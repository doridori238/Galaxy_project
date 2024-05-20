using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu]
public class ItemDropList : ScriptableObject
{    
    public List<GameObject> itemList;

    public GameObject this[int i]
    {
        get
        {
            return itemList[i];
        }
    }

    public int Count
    {
        get => itemList.Count;
    }


}
