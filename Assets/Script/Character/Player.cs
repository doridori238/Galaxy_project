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
    {// �ٴڰ� �ε�ġ�� ���� �Ұ� �ϰ� �ϱ� 
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
    /// ġ��Ÿ Ȯ��
    /// </summary>
    [SerializeField] float crt;
    public float Crt
    {
        get { return crt; }
        set { crt = value; }
    
    }

    /// <summary>
    /// ���ݷ� ����
    /// </summary>
    float str;
    /// <summary>
    /// ���ݷ� ���� + �̵��ӵ�
    /// </summary>
    float dex;



    private void Start()
    {
        playerRd = GetComponent<Rigidbody2D>();
        jumpButton.onClick.AddListener(() => { playerRd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); Debug.Log("����"); });
       
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

// 1. �÷��̾�� �������� Ʈ���Ű� �Ͼ�� �������� �κ��丮[����]�� �÷��̾ �����ش�.
// 2. ������ �������� UI�� �������Ѵ�. [��������Ʈ , ������ �̸�]


//Slot slot = inven.instance.slots[0];
//Item slotitem = collision.gameObject.GetComponent<BasicSword>().currentItem;
//slot.SetSlot(slotitem);


//IComponentable currentitemCompo = collision.gameObject.GetComponent<IComponentable>();
//compositeinvenslot.Add(currentitemCompo, itemImage);
