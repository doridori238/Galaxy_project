using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillState : MonoBehaviour, IPointerDownHandler
{
    public SKILL getskills;
   
    public void OnPointerDown(PointerEventData eventData)
    {  
       // Debug.Log("��ų ���Ѵ�" + gameObject.name + this.gameObject.name);
        if (gameObject.name == this.gameObject.name)
            Player.instance.SKILLS = getskills;
    }
}
