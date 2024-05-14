using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InterfaceManager;

public class inven : Singleton<inven>
{
    public Slot[] slots;

    
    void Start()
    {
        slots = GetComponentsInChildren<Slot>();
    }

    
    void Update()
    {
        
    }


}
