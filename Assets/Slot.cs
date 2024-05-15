using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static InterfaceManager;

public class Slot : MonoBehaviour, IGetItemDataAble ,IPointerDownHandler,IPointerUpHandler,IPointerClickHandler
{
    public Image itemSprite;
    public TextMeshProUGUI itemName;

    public GameObject detailUi;
    public TextMeshProUGUI detaildata;
    public Image detalItemImage;

    public Button[] detailUibuttons = new Button[3];

    ItemClass itemClass1;
    public Item slotitem;
    Item nullItem;

    Player player;
    
    private void Start()
    {
        player = Player.instance;
        detailUibuttons[0].onClick.AddListener(() => { Use(); }); 
        detailUibuttons[1].onClick.AddListener(() => { ReMove(); }); 
        detailUibuttons[2].onClick.AddListener(() => { detailUi.SetActive(false); });

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
        Debug.Log("���� ���Ͷ�");
    }

    public void Use()
    {
        itemClass1.ItemUse(player);
        
        Debug.Log("Use");
    }

    public void ReMove()
    {
        detaildata.text= null;
        detalItemImage.sprite = null;
        itemSprite.sprite = null;
        itemName.text = null;
        itemClass1 = null;
        slotitem = nullItem;

        Debug.Log("remove");

        // ������ ������();
        // ���Կ��� ������!
    }

    public void GetItemDataAble(ISendItemDataAble OnSendItemData)
    {
         Debug.Log("������ ���� " + OnSendItemData);
        
         itemClass1 = OnSendItemData.GetItemClass();

         slotitem = itemClass1.ItemClassName.CurrentItem;
         SetSlot(slotitem);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(gameObject.name +"�ٿ�");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + "��");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + "Ŭ��");
        detailUi.SetActive(true);
        detaildata.text = slotitem.itemname + slotitem.lvlimit + slotitem.value1 ;
        detalItemImage.sprite = slotitem.sprite;
    }
}

//1. ������ Ŭ���� ��� ���� �� �� ���� ��������� ����Լ�
//2. �κ��丮 ��� �����