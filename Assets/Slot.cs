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

    public Item slotitem;

    private void Start()
    {
        //detailUibuttons[0].onClick.AddListener(); ����ϴ� ��ư
        //detailUibuttons[1].onClick.AddListener(); ������ ��ư
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
        //������.�����ۻ��();
    
    }

    public void ReMove()
    { 
        // ������ ������();
        // ���Կ��� ������!
    }

    public void GetItemDataAble(ISendItemDataAble OnSendItemData)
    {
         Debug.Log("������ ���� " + OnSendItemData);

         slotitem = OnSendItemData.GetItem();
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
        detaildata.text = slotitem.itemname ;
        detalItemImage.sprite = slotitem.sprite;
    }
}
