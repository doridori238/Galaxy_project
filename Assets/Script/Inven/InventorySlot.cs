using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    //리스트에 담아서 쓰기

    // 아이템 타입으로 분류된 아이템을 인벤토리 와 연결
    //  itemData에 분류된 데이터를 가지고 와서 사용하는 곳! Ui랑 도 연동 되는 곳
    // 인벤토리는 bool 여부로 비어 있는지 판단 후 들어갈 수 있도록
    [SerializeField]GameObject[] slot;
    bool check = false;

    public void Start()
    {
        InvenSlot(slot);
    }


    //뜨앗 데이터 들어있는 여부 체크 하고 들어가면 List에 들어가도록 하고 아이템을 사용하면 remove로 빼주고 지금 상태는 배경 슬롯을 그냥 리스트에 담고 있는 쓸대 없는 상황
    public List<GameObject> InvenSlot(GameObject[] slot) // 더해주는 것과 빼주는 것 두개다 만들기
    {
        List<GameObject> list = new List<GameObject>();

        for (int i = 0; i < slot.Length; i++)
        { 
            if(slot == null)
                list.Add(slot[i]);
            else 
                return list;
        }
       
        return list;
    
    }



}
