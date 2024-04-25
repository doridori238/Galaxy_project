using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clint : MonoBehaviour
{
    Leaf leaf = new Leaf(); 
    Leaf leaf2= new Leaf();
    Leaf leaf3 = new Leaf();
    Leaf leaf4 = new Leaf();
    Leaf leaf5 = new Leaf();


    Composite composite = new Composite();
    Composite composite2 = new Composite();
    Composite composite3 = new Composite();



    void Start()
    {
        composite.Add(leaf);
        composite.Add(leaf2);

        composite2.Add(leaf3);
        composite3.Add(leaf4);

        composite2.Add(leaf5);

        composite2.Add(composite);
        composite3.Add(composite3);

        composite.GetChild();
    }

  
}
