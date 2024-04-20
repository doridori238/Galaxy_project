using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Testjoy : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform handle = null;
    public Transform transform = null;
    public RectTransform joystickq = null;
    private AxisOptions axisOptions = AxisOptions.Vertical;
    private Vector2 input1 = Vector2.zero;

    private void Start()
    {
        handle = GetComponent<RectTransform>();
        transform = this.GetComponent<Transform>();
    }

    private void Update()
    {
        if (handle != null)
            return;

        input1.y = handle.localPosition.y;

       
       // transform.transform.localPosition = handle.localPosition;

        //if (handle.transform.position  ==  )
        //{

        //}

        //float 
        //   == AxisOptions.Vertical
        //y축 -63 63

    }

    // 1. 핸들의 위치를 up,down,right,left 알아올 수 있도록 만들고(핸들 -1,0,1)
    // 아님 원하는 위치에 ui와 부딪치면 점프..?
    // 2. 조건에 맞춰서 (if문) up일떄는 addforce , velocity둔 점프 만들고 
    // 3 . down은 return으로 처리한다.

    private float SnapVerical(float value ,AxisOptions axisOptions)
    {
        float angle = Vector2.Angle(input1,Vector2.up);
        if(value == 0)
            return value;
        if (axisOptions == AxisOptions.Vertical)
        {
            if (angle > -63.3f && angle < 63.3f)
                return 0;
            else
                return (value > 0) ? 1 : -1 ;
        }
        return value;
    }




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
