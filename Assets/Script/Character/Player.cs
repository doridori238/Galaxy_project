using System;
using UnityEngine;
using UnityEngine.UI;
using static ComponentPattern;
using static InterfaceManager;
public class Player : Singleton<Player>, ISendItemDataAble, IGetItemDataAble
{
    public Button jumpButton;
    public FixedJoystick joystick = null;
    public RectTransform handle = null;
    public Slot slot;

    Rigidbody2D playerRd;
    float maxspeed = 3f;
    Vector2 hMoveVelocity;

    float jumpForce = 20;
    bool isJumping = true;
    public bool IsJumping
    {// 바닥과 부딪치면 점프 불가 하게 하기 
        get { return isJumping; }
        set { isJumping = value; }
    }

    float hjoy;

    [SerializeField]float hp = 100;
    float maxhp = 500;

    
    public float Hp
    {
        get { return hp; }
        set { hp = value;
            Debug.Log(Hp); 
        }
    }

    float mp;
    float maxMp = 500;

    public float Mp
    {
        get { return mp; }
        set { maxMp = mp; }
    }

    /// <summary>
    /// 치명타 확률
    /// </summary>
    [SerializeField] float crt;
    public float Crt
    {
        get { return crt; }
        set { crt = value; }
    
    }

    /// <summary>
    /// 공격력 대폭
    /// </summary>
    float str;
    /// <summary>
    /// 공격력 소폭 + 이동속도
    /// </summary>
    float dex;



    private void Start()
    {
        playerRd = GetComponent<Rigidbody2D>();
        jumpButton.onClick.AddListener(() => { playerRd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); Debug.Log("점프"); });
       
    }


    private void Update()
    {
        hjoy = joystick.Horizontal;

    }

    private void FixedUpdate()
    {

        playerRd.AddForce(Vector2.right*hjoy, ForceMode2D.Impulse);

        if (playerRd.velocity.x > maxspeed)
            playerRd.velocity = new Vector2(maxspeed, playerRd.velocity.y);

        else if (playerRd.velocity.x < maxspeed * (-1))
            playerRd.velocity = new Vector2(maxspeed * (-1), playerRd.velocity.y);

        else if (playerRd.velocity.y > maxspeed * 3)
            playerRd.velocity = new Vector2(playerRd.velocity.x, maxspeed * 2);

    
    }



    InventorySlot compositeinvenslot = new InventorySlot();

    


    private void OnTriggerEnter2D(Collider2D collision)
    {

        ISendItemDataAble item = collision.gameObject.GetComponent<ISendItemDataAble>();
        slot.GetItemDataAble(item);
        collision.gameObject.SetActive(false);


    }

   

    public Item GetItem()
    {
        throw new NotImplementedException();
    }


    public void GetItemDataAble(ISendItemDataAble OnSendItemData)
    {
        Debug.Log(OnSendItemData);

    }


    void Die()
    {


    }


    void Hit()
    {



    }

    public ItemClass GetItemClass()
    {
        throw new NotImplementedException();
    }
}


//Sprite itemImage = collision.gameObject.GetComponent<SpriteRenderer>().sprite;

// item = collision.gameObject.GetComponent<ISendItemDataAble>().GetItem();
//slot.GetItemDataAble(item);

// 1. 플래이어와 아이템이 트리거가 일어나면 아이템을 인벤토리[슬롯]에 플래이어가 보내준다.
// 2. 보내진 아이템이 UI에 보여야한다. [스프라이트 , 아이템 이름]


//Slot slot = inven.instance.slots[0];
//Item slotitem = collision.gameObject.GetComponent<BasicSword>().currentItem;
//slot.SetSlot(slotitem);


//IComponentable currentitemCompo = collision.gameObject.GetComponent<IComponentable>();
//compositeinvenslot.Add(currentitemCompo, itemImage);
