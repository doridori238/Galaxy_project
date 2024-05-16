using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static ComponentPattern;
using static InterfaceManager;
public class Player : Singleton<Player>, ISendItemDataAble, IGetItemDataAble
{
    public Button jumpButton;
    public FixedJoystick joystick = null;
    public RectTransform handle = null;
    public SpriteRenderer playersprite;
    
    Rigidbody2D playerRd;
    float maxspeed = 3f;
    Vector2 hMoveVelocity;

    SKILL skills;

    public SKILL SKILLS
    { 
        get { return skills; }
        set {
              skills = value;
              Debug.Log(SKILLS);
        }
    }

    
    public bool PlayerForwardSprite
    {
        get { return playersprite.flipX; }
        set { playersprite.flipX = value; 
        Debug.Log(PlayerForwardSprite);
        }
    }

    float jumpForce = 30;
    bool isJumping = true;
    public bool IsJumping
    {
        get { return isJumping; }
        set { isJumping = value; }
    }

    float hjoy;

    [SerializeField] int playerLv = 1;
    public int PlayerLV
    {
        get { return playerLv; }
        set { playerLv = value; }
    }


    [SerializeField] float hp;
    
    public float Hp
    {
        get { return hp; }
        set { hp = value;
            Debug.Log(Hp);
        }
    }

    float mp = 0;
    float maxMp = 500;

    public float Mp
    {
        get { return mp; }
        set { mp = value;
            if (Mp >= maxMp)
                PlayerLV += 1;
        }
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
        playersprite = GetComponent<SpriteRenderer>();
        playerRd = GetComponent<Rigidbody2D>();
        jumpButton.onClick.AddListener(() => {
            if (IsJumping == true)
            { 
                playerRd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
                IsJumping= false;
            }
            else
                return;
        
        });

    }


    private void Update()
    {
        hjoy = joystick.Horizontal;

    }

    RaycastHit2D enemyhit;
    Enemy targetenemy;

    private void FixedUpdate()
    {
        playerRd.AddForce(Vector2.right * hjoy, ForceMode2D.Impulse);
        PlayerMove();
        enemyhit = Physics2D.Raycast(playerRd.velocity,new Vector2(playerRd.position.x,playerRd.position.y),5,1<<8);
        if (enemyhit.rigidbody != null)
        {
            targetenemy = enemyhit.rigidbody.GetComponent<Enemy>();
            Attack(targetenemy);
        }
        else
            return;

        //if (playersprite.flipX == true)
        //{
        //    attackZone.offset = new Vector2(-3, 0);
        //    attackZone.size = new Vector2(4, 0);
        //}
        //else
        //{ 
        //    attackZone.offset = new Vector2(3, 0);
        //    attackZone.size = new Vector2(4, 0);
        //}
    }

    void PlayerMove()
    {
        if (playerRd.velocity.x > maxspeed)
        {
            playerRd.velocity = new Vector2(maxspeed, playerRd.velocity.y);
            PlayerForwardSprite = true;
            
        }

        else if (playerRd.velocity.x < maxspeed * (-1))
        { 
            playerRd.velocity = new Vector2(maxspeed * (-1), playerRd.velocity.y);
            PlayerForwardSprite = false;
           
        }

        else if (playerRd.velocity.y > maxspeed * 3)
            playerRd.velocity = new Vector2(playerRd.velocity.x, maxspeed * 2);

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ISendItemDataAble>() != null)
        {
            ISendItemDataAble item = collision.gameObject.GetComponent<ISendItemDataAble>();
            InvenUi.instance.GetItemDataAble(item);
            collision.gameObject.SetActive(false);
        }
        else
            return;
        //else if(collision.gameObject.GetComponent<Enemy>() != null)
           
        //    Attack(targetenemy);

        Debug.Log("내가 먹었따");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        int floorlayer = collision.gameObject.layer;
        Debug.Log(floorlayer);
        if (floorlayer == LayerMask.NameToLayer("Floor"))
             IsJumping = true;

    }


    public void GetItemDataAble(ISendItemDataAble OnSendItemData)
    {
        Debug.Log(OnSendItemData);

    }


    void Die()
    {
        //애니메이션
    }


    void Hit()
    {
        // 애니메이션
    }

   public  BoxCollider2D attackZone;

    void Attack(Enemy targa)
    {
        Debug.Log("타겟의 목숨 줄인다!!!");
        switch (SKILLS)
        {
            case SKILL.BASIC_ATTACK:
                //attackZone.
                //if (PlayerForwardSprite == true)
                //    attackZone.GetComponent<BoxCollider2D>().offset.Set(3,0);
                //else
                //    attackZone.GetComponent<BoxCollider2D>().offset.Set(-3, 0);

                targa.EnemyHP -= Crt;
                break;

            case SKILL.LITTLE_ATTACK:
                //attackZone.GetComponent<BoxCollider2D>().size.Set(2, 0);
                //if (PlayerForwardSprite == true)
                //    attackZone.GetComponent<BoxCollider2D>().offset.Set(2, 0);
                //else
                //    attackZone.GetComponent<BoxCollider2D>().offset.Set(-2, 0);

                targa.EnemyHP -= Crt * 1.5f;
                break;
            case SKILL.BIG_ATTACK:
                //attackZone.GetComponent<BoxCollider2D>().size.Set(10, 0);
                //attackZone.GetComponent<BoxCollider2D>().offset.Set(0, 0);

                targa.EnemyHP -= Crt * 0.7f;
                break;
        
        }

    }

  

    public ItemClass GetItemClass()
    {
        throw new NotImplementedException();
    }


}

public enum SKILL
{ 
    BASIC_ATTACK, LITTLE_ATTACK,BIG_ATTACK
}

