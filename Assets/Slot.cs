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
        //detailUibuttons[0].onClick.AddListener(); 사용하는 버튼
        //detailUibuttons[1].onClick.AddListener(); 버리는 버튼
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
        Debug.Log("젭알 나와라");
    }

    public void Use()
    { 
        //아이템.아이템사용();
    
    }

    public void ReMove()
    { 
        // 아이템 버리기();
        // 슬롯에서 버리기!
    }

    public void GetItemDataAble(ISendItemDataAble OnSendItemData)
    {
         Debug.Log("아이템 받음 " + OnSendItemData);

         slotitem = OnSendItemData.GetItem();
         SetSlot(slotitem);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(gameObject.name +"다운");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + "업");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + "클릭");
        detailUi.SetActive(true);
        detaildata.text = slotitem.itemname ;
        detalItemImage.sprite = slotitem.sprite;
    }
}
