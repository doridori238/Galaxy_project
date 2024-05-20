using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static InterfaceManager;
using static UnityEditor.Progress;

public class Slot : MonoBehaviour, IGetItemDataAble ,IPointerClickHandler
{
    public Image itemSprite;
    public TextMeshProUGUI itemName;

    public GameObject detailUi;
    public TextMeshProUGUI detaildata;
    public Image detalItemImage;

    public Button[] detailUibuttons = new Button[3];

    public ItemClass itemClass1;
    public Item slotitem;
    Item nullItem;

    Slot thisSlot;
    Player player;

    PointerEventData eventData;
    EventSystem buttonevent;

    private void Start()
    {
        thisSlot = gameObject.GetComponent<Slot>();
        player = Player.instance;

    }

    public void SetSlot(Item item)
    {
        slotitem = item;
        if (slotitem.itemname != null)
        {
            itemSprite.sprite = item.sprite;
            itemName.text = item.itemname;
        }
        else
        { 
            itemSprite.sprite = null;
            itemName.text = "";
        }
        Debug.Log("젭알 나와라");
    }

    public void Use()
    {
        if (itemClass1 == null)
            return;
        else if (itemClass1 != null)
        {
            if (slotitem.lvlimit == LV_LIMIT.ONE_LV)
            {
                itemClass1.ItemUse(player);
                ReMove();
            }
            else if (slotitem.lvlimit == LV_LIMIT.FIVE_LV && Player.instance.PlayerLV == 5)
            {
                itemClass1.ItemUse(player);
                ReMove();
            }
            else if (slotitem.lvlimit == LV_LIMIT.TEN_LV && Player.instance.PlayerLV == 10)
            {
                itemClass1.ItemUse(player);
                ReMove();
            }
            else
                return;
        }

        Debug.Log("Use");
    }

    public void ReMove()
    {
        gameObject.GetComponent<Slot>().itemClass1 = null;
        gameObject.GetComponent<Slot>().slotitem = nullItem;
        gameObject.GetComponent<Slot>().SetSlot(nullItem);

        Debug.Log("remove");

    }

    public void GetItemDataAble(ISendItemDataAble OnSendItemData)
    {
         Debug.Log("아이템 받음 " + OnSendItemData);
         itemClass1 = OnSendItemData.GetItemClass();
         slotitem = itemClass1.ItemClassName.CurrentItem;
         SetSlot(slotitem);

    }

   
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + "클릭");
        detailUi.SetActive(true);
        detaildata.text = slotitem.itemname + slotitem.lvlimit + slotitem.value1 ;
        detalItemImage.sprite = slotitem.sprite;
        detailUibuttons[0].onClick.AddListener(() => { Use(); });
        detailUibuttons[1].onClick.AddListener(() => { ReMove(); });
        detailUibuttons[2].onClick.AddListener(() => { detailUi.SetActive(false); });
       
    }


  
}

