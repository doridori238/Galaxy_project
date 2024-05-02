using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ComponentPattern;
using static InterfaceManager;

public class InventorySlot : MonoBehaviour, IComponentable
{
    //리스트에 담아서 쓰기
    [SerializeField]private List<IComponentable> itemLeaf = new List<IComponentable>();
    Dictionary<List<IComponentable>, List<Sprite>> invenUi = new Dictionary<List<IComponentable>, List<Sprite>>();
    [SerializeField] List<Sprite> itemSprite = new List<Sprite>();
    [SerializeField] GameObject[] slot = new GameObject[20];
    [SerializeField] GameObject detailDataUi;

    // 아이템 타입으로 분류된 아이템을 인벤토리 와 연결
    //  itemData에 분류된 데이터를 가지고 와서 사용하는 곳! Ui랑 도 연동 되는 곳
    // 인벤토리는 bool 여부로 비어 있는지 판단 후 들어갈 수 있도록
    bool check = false;

    public void Start()
    {
        //InvenSlot(slot);
        detailDataUi.GetComponentInChildren<Renderer>();

    }


    private void Update()
    {
        
    }

    /// <summary>
    /// componentpattern.add part
    /// </summary>
    /// <param name="leaf"></param>
    public void Add(IComponentable item , Sprite sprite )//(IComponentable item, GameObject[] slot)
    {
        itemLeaf.Add(item);
        itemSprite.Add(sprite);
        Debug.Log(item);

    }

    /// <summary>
    /// componentpattern.remove part
    /// </summary>
    /// <param name="leaf"></param>
    public void Remove(IComponentable item, Sprite sprite)//(IComponentable item, GameObject[] slot)
    {
        itemLeaf.Remove(item);
        itemSprite.Remove(sprite);
    }

    /// <summary>
    /// componentpattern child search
    /// </summary>
    public void GetChild()
    {
        //childLeaf.GetRange(0, childLeaf.Count);  
        // 들어오는 아이템들을 찾고 확인 작업 이 부분은 트리로 만들어도 나쁘지 않을 듯 한데 일단 만들고 생각
        foreach (IComponentable item in itemLeaf)
        {
            Debug.Log(item);
        }

    }

    /// <summary>
    /// 재귀 or 반복문을 통해서 아이템 정보 확인? 뭐하는 함수인지 잘 모르겠지만 영어의 뜻은 작전이기에 생각 하고 구현 부족한 기능 구현
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void Operation()
    {
        throw new System.NotImplementedException();
    }



    // 데이터가 들어있지 않은 slot은 SetActive(false)가 되도록 만들어주고 만약 데이터가 배열 크기보다 많다면 추가하던가 아님 아이템을 버리거나 할 수 있도록 만들어 주자
    //뜨앗 데이터 들어있는 여부 체크 하고 들어가면 List에 들어가도록 하고 아이템을 사용하면 remove로 빼주고 지금 상태는 배경 슬롯을 그냥 리스트에 담고 있는 쓸대 없는 상황
    //ui이랑 연결되는 인벤
    //public List<GameObject> InvenSlot(GameObject[] slot) // 더해주는 것과 빼주는 것 두개다 만들기
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

   
}
