using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T instance = null ;
    void Start()
    {
        if (instance == null)
            instance = (T)this;
        else
            Destroy(gameObject);
                
    }  

}
