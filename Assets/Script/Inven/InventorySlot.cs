using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    //����Ʈ�� ��Ƽ� ����

    // ������ Ÿ������ �з��� �������� �κ��丮 �� ����
    //  itemData�� �з��� �����͸� ������ �ͼ� ����ϴ� ��! Ui�� �� ���� �Ǵ� ��
    // �κ��丮�� bool ���η� ��� �ִ��� �Ǵ� �� �� �� �ֵ���
    [SerializeField]GameObject[] slot;
    bool check = false;

    public void Start()
    {
        InvenSlot(slot);
    }


    //�߾� ������ ����ִ� ���� üũ �ϰ� ���� List�� ������ �ϰ� �������� ����ϸ� remove�� ���ְ� ���� ���´� ��� ������ �׳� ����Ʈ�� ��� �ִ� ���� ���� ��Ȳ
    public List<GameObject> InvenSlot(GameObject[] slot) // �����ִ� �Ͱ� ���ִ� �� �ΰ��� �����
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
