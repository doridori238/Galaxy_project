using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class SkillState : MonoBehaviour, IPointerDownHandler
{
    public SKILL getskills;
    public Image skillImgae;
    float cooltime = 10;
    public float maxCooltime = 10;

    bool cool;
    public bool Cool
    {
        get { return cool; }
        set { cool = value; }
    }


    private void Start()
    {
        skillImgae = GetComponent<Image>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {  
       // Debug.Log("스킬 변한다" + gameObject.name + this.gameObject.name);
        if (gameObject.name == this.gameObject.name)
            Player.instance.SKILLS = getskills;

        Player.instance.PointerEnterValue = gameObject.name;
        Cool = true;
    }

    private void FixedUpdate()
    {
        if (Cool == true)
            CoolTime();
        else
            return;
    }


    public void CoolTime()
    {
        cooltime -= Time.smoothDeltaTime;
        skillImgae.fillAmount = cooltime / maxCooltime;
        //Debug.Log(cooltime);
        if (skillImgae.fillAmount == 0)
        {
            Cool = false;
            skillImgae.fillAmount = 1;
        }

    }


}
