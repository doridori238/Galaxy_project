using System;
using UnityEngine;
using UnityEngine.UI;
using static ComponentPattern;
using static InterfaceManager;
public class Player : MonoBehaviour, ISendItemDataAble, IGetItemDataAble
{
    public Button jumpButton;
    public FixedJoystick joystick = null;
    public RectTransform handle = null;


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

    float hp;
    float maxhp = 500;
    public float Hp
    {
        get { return hp; }
        set { hp = maxhp; }
    }

    float mp;
    float maxMp = 500;

    public float MaxMp
    {
        get { return mp; }
        set { mp = maxMp; }
    }

    /// <summary>
    /// 치명타 확률
    /// </summary>
    float crt;
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
        ISendItemDataAble currentitem = collision.gameObject.GetComponent<ISendItemDataAble>();
        GetItemDataAble(currentitem);

        IComponentable currentitemCompo = collision.gameObject.GetComponent<IComponentable>();
        compositeinvenslot.Add(currentitemCompo);

        compositeinvenslot.GetChild();

    }


    public Item OnSendItemDataAble(Item item)
    {
        throw new NotImplementedException();
    }


    public void GetItemDataAble(ISendItemDataAble OnSendItemData)
    {
        Debug.Log(OnSendItemData);
    }
}


