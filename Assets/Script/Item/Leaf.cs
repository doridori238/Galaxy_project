using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ComponentPattern;

public class Leaf : MonoBehaviour, IComponentable
{
    public Leaf name;
    public void Operation()
    {
        Debug.Log("������"); 
    }
}
  

