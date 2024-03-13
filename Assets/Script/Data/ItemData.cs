using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using static UnityEditor.Progress;


public class ItemData : MonoBehaviour
{
    
    List<Item> itemData = new List<Item>();
    

    void Start()
    {

        itemData = DataLoad.instance.valuesList;
       
      
    }
    //아이템 디테일 enum에 맞춰서 아이템이 디버깅 되도록 하기
    // 인벤토리와 무기 장비 연결을 위한 토대 
    // WEAPON, detail = 5 , //enum을 int로 박싱
    // 아이템 전체 데이터를 가지고 분류 작업 해준다.
    // 리스트에 담아주자 딕셔너리

   



   
}

