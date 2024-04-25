using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentPattrn : MonoBehaviour
{
    public interface IComponentable
    {
        public void Operation();
        
    }
}