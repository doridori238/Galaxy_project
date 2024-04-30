 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ComponentPattern;

public class Composite : MonoBehaviour, IComponentable
{
    private List<IComponentable> childLeaf = new List<IComponentable>();
    Item item;

    public void Operation()
    {
        Debug.Log("¹«±â");
    }


    public void Add(IComponentable leaf)
    {
        childLeaf.Add(leaf);
    }


    public void Remove(IComponentable leaf) 
    {
        childLeaf.Remove(leaf);
    }


    public void GetChild() 
    {
        //childLeaf.GetRange(0, childLeaf.Count);
         foreach (IComponentable leaf in childLeaf)
        {
            Debug.Log(leaf);
        }
                
    }

}

