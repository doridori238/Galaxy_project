using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ITEMDETAIL
{
    WEAPON = 0,
    HP_POTION = 5,
    MP_POTION = 6
}

public enum ITEMTYPE
{
    CONSUMPTION = 1, // 소모형 아이템
    MOUNTING = 0     // 장착형 아이템 
}

public class ItemData : MonoBehaviour
{
    DataLoad dataLoad;

    void Start()
    {
        // int itemtype  = dataLoad.itemDic[0].itemtype;

    }
    //아이템 디테일 enum에 맞춰서 아이템이 디버깅 되도록 하기
    // 인벤토리와 무기 장비 연결을 위한 토대 
    // WEAPON, detail = 5 , //enum을 int로 박싱
    // 아이템 전체 데이터를 가지고 분류 작업 해준다.
    // 리스트에 담아주자 딕셔너리

    public void DivisionItemType(Dictionary<int,Item> itemDic) // 아이템 타입 분류 [ 장착 하느냐 소비하느냐  이걸 체크하기 위해 함 ]
    { 
        

        //if (itemDic[i].itemtype == ITEMTYPE.CONSUMPTION)

        //    else
        //    itemDic[i].itemtype == ITEMTYPE.MOUNTING;
        //    return;
    }

    public void DivisionItemDetail(Dictionary<int, Item> itemDic) // 아이템 디테일 분류
    { 
       // 스위치 문으로 구현
    
    }


    public void DivisionItem() // 아이템 내림차순 분류 
    {
        //  이건 일단 있어보기 어디서 가져다 쓰려나..

    }


}

