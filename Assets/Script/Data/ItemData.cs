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
    //������ ������ enum�� ���缭 �������� ����� �ǵ��� �ϱ�
    // �κ��丮�� ���� ��� ������ ���� ��� 
    // WEAPON, detail = 5 , //enum�� int�� �ڽ�
    // ������ ��ü �����͸� ������ �з� �۾� ���ش�.
    // ����Ʈ�� ������� ��ųʸ�

   



   
}

