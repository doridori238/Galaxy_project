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
        //y�� -63 63

    }

    // 1. �ڵ��� ��ġ�� up,down,right,left �˾ƿ� �� �ֵ��� �����(�ڵ� -1,0,1)
    // �ƴ� ���ϴ� ��ġ�� ui�� �ε�ġ�� ����..?
    // 2. ���ǿ� ���缭 (if��) up�ϋ��� addforce , velocity�� ���� ����� 
    // 3 . down�� return���� ó���Ѵ�.

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
