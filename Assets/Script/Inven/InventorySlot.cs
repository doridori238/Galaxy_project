using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static ComponentPattern;
using static InterfaceManager;

public class InventorySlot : MonoBehaviour, IComponentable
{
    //����Ʈ�� ��Ƽ� ����
    [SerializeField] private List<IComponentable> itemLeaf = new List<IComponentable>();
    [SerializeField] List<Sprite> itemSprite = new List<Sprite>();
    [SerializeField] Slot[] slot;
    [SerializeField] GameObject detailDataUi;
    [SerializeField] GameObject itemdetailUiImage;
    public Transform slotholer;


    public delegate void SlotcountDel(int slot);
    public SlotcountDel slotcountDel;

    int slotcount = 20;
    public int SlotCount
    {
        get { return slotcount; }
        set { slotcount = value;
            slotcountDel.Invoke(SlotCount);
        }
    }
   
   

    public void Start()
    {
        //InvenSlot(slot);
        slot = new Slot[slot.Length];
        
    }


    private void Update()
    {

    }


    //public void SlotChange(Slot[] slot)
    //{
    //    for (int i = 0; i < slot.Length ; i++)
    //    {

    //        if (i < )
    //        { }
    //        else
        
    //    }
    //}



    /// <summary>
    /// componentpattern.add part
    /// </summary>
    /// <param name="leaf"></param>
    public void Add(IComponentable item,Sprite sprite)//(IComponentable item, GameObject[] slot)
    {
        itemLeaf.Add(item);
        itemSprite.Add(sprite);
        //invenUi.Add(itemLeaf[item], itemSprite[sprite]);
        Debug.Log(item);

    }

    /// <summary>
    /// componentpattern.remove part
    /// </summary>
    /// <param name="leaf"></param>
    public void Remove(IComponentable item)//(IComponentable item, GameObject[] slot)
    {
        itemLeaf.Remove(item);
        //itemSprite.Remove(sprite);
    }

    /// <summary>
    /// componentpattern child search
    /// </summary>
    public void GetChild()
    {
        //childLeaf.GetRange(0, childLeaf.Count);  
        // ������ �����۵��� ã�� Ȯ�� �۾� �� �κ��� Ʈ���� ���� ������ ���� �� �ѵ� �ϴ� ����� ����
        foreach (IComponentable item in itemLeaf)
        {
            Debug.Log(item);
        }

    }

    /// <summary>
    /// ��� or �ݺ����� ���ؼ� ������ ���� Ȯ��? ���ϴ� �Լ����� �� �𸣰����� ������ ���� �����̱⿡ ���� �ϰ� ���� ������ ��� ����
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void Operation()
    {
        throw new System.NotImplementedException();
        Operation();
    }

    public void Slots(GameObject[] slot)
    {
       for(int i = 0; i < 20; i++)
        {
            if (slot[i].GetComponent<Image>().sprite == null)
            {
                
            }

        }



           // if (slot[0].GetComponent<Image>().sprite == null)
         
   
    
    
    }





   
}


    // �����Ͱ� ������� ���� slot�� SetActive(false)�� �ǵ��� ������ְ� ���� �����Ͱ� �迭 ũ�⺸�� ���ٸ� �߰��ϴ��� �ƴ� �������� �����ų� �� �� �ֵ��� ����� ����
    //�߾� ������ ����ִ� ���� üũ �ϰ� ���� List�� ������ �ϰ� �������� ����ϸ� remove�� ���ְ� ���� ���´� ��� ������ �׳� ����Ʈ�� ��� �ִ� ���� ���� ��Ȳ
    //ui�̶� ����Ǵ� �κ�
    //public List<GameObject> InvenSlot(GameObject[] slot) // �����ִ� �Ͱ� ���ִ� �� �ΰ��� �����
    //{
    //    List<GameObject> list = new List<GameObject>();

    //    for (int i = 0; i < slot.Length; i++)
    //    {
    //        if (slot == null)
    //            list.Add(slot[i]);
    //        else
    //            return list;
    //    }

    //    return list;

    //}