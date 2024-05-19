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
    public float cooltime = 3;
    public float maxCooltime = 3;
    public GameObject attackZone;
    public GameObject skillLockImage;

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
        
        attackZone.gameObject.SetActive(true);
        if (gameObject.name == skillLockImage.name)
            return;
    }


    private void FixedUpdate()
    {
        if (Cool == true)
        { 
            CoolTime();
            skillLockImage.gameObject.SetActive(true);
        }

        else if(Cool == false)
            skillLockImage.gameObject.SetActive(false);
          
    }


    public void CoolTime()
    {
        cooltime -= Time.smoothDeltaTime;
        skillImgae.fillAmount = cooltime / maxCooltime;
        if (skillImgae.fillAmount == 0)
        {
            Cool = false;
            skillImgae.fillAmount = 1;
            cooltime = 3;
        }
        
    }


}
