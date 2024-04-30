using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ComponentPattern;

public class InventorySlot : MonoBehaviour, IComponentable
{
    //����Ʈ�� ��Ƽ� ����
    private List<IComponentable> itemLeaf = new List<IComponentable>();

    // ������ Ÿ������ �з��� �������� �κ��丮 �� ����
    //  itemData�� �з��� �����͸� ������ �ͼ� ����ϴ� ��! Ui�� �� ���� �Ǵ� ��
    // �κ��丮�� bool ���η� ��� �ִ��� �Ǵ� �� �� �� �ֵ���
    [SerializeField]GameObject[] slot;
    bool check = false;

    public void Start()
    {
       // InvenSlot(slot);
    }

    /// <summary>
    /// componentpattern.add part
    /// </summary>
    /// <param name="leaf"></param>
    public void Add(IComponentable leaf) 
    {
        itemLeaf.Add(leaf);
    }

    /// <summary>
    /// componentpattern.remove part
    /// </summary>
    /// <param name="leaf"></param>
    public void Remove(IComponentable leaf)
    {
        itemLeaf.Remove(leaf);
    }

    /// <summary>
    /// componentpattern child search
    /// </summary>
    public void GetChild()
    {
        //childLeaf.GetRange(0, childLeaf.Count);  
        // ������ �����۵��� ã�� Ȯ�� �۾� �� �κ��� Ʈ���� ���� ������ ���� �� �ѵ� �ϴ� ����� ����
        foreach (IComponentable leaf in itemLeaf)
        {
            Debug.Log(leaf);
        }

    }

    /// <summary>
    /// ��� or �ݺ����� ���ؼ� ������ ���� Ȯ��? ���ϴ� �Լ����� �� �𸣰����� ������ ���� �����̱⿡ ���� �ϰ� ���� ������ ��� ����
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void Operation()
    {
        throw new System.NotImplementedException();
    }



    // �����Ͱ� ������� ���� slot�� SetActive(false)�� �ǵ��� ������ְ� ���� �����Ͱ� �迭 ũ�⺸�� ���ٸ� �߰��ϴ��� �ƴ� �������� �����ų� �� �� �ֵ��� ����� ����
    //�߾� ������ ����ִ� ���� üũ �ϰ� ���� List�� ������ �ϰ� �������� ����ϸ� remove�� ���ְ� ���� ���´� ��� ������ �׳� ����Ʈ�� ��� �ִ� ���� ���� ��Ȳ
    //public List<GameObject> InvenSlot(GameObject[] slot) // �����ִ� �Ͱ� ���ִ� �� �ΰ��� �����
    //{
    //    List<GameObject> list = new List<GameObject>();

    //    for (int i = 0; i < slot.Length; i++)
    //    { 
    //        if(slot == null)
    //            list.Add(slot[i]);
    //        else 
    //            return list;
    //    }
       
    //    return list;
    
    //}



}
