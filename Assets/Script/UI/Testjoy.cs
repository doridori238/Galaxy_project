using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Testjoy : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{


    public TextMeshProUGUI text;

    public void OnDrag(PointerEventData eventData)
    {
        text.text = "Drag";
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        text.text = "Down";
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        text.text = "Up";
    }

   
}
