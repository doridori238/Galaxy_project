using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentPattern : MonoBehaviour
{
    public interface IComponentable
    {
        public void Operation();
        
    }
}