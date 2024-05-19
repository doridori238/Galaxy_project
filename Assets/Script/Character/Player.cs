using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static ComponentPattern;
using static InterfaceManager;
using static UnityEngine.GraphicsBuffer;

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
           // Debug.Log(Hp);
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
        attackZone = attackZone.GetComponent<BoxCollider2D>();
      
    }


    private void Update()
    {
        hjoy = joystick.Horizontal;

    }

    RaycastHit2D enemyhit;
    Enemy[] targetenemy;

    private void FixedUpdate()
    {
        playerRd.AddForce(Vector2.right * hjoy, ForceMode2D.Impulse);
        PlayerMove();
        AttackZoneRange();

      

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


    String pointerEntervalue;

    public String PointerEnterValue
    {
        get { return pointerEntervalue; }
        set { pointerEntervalue = value;
            Debug.Log("�̺�Ʈ ����");
        }
    }

    public GameObject[] skillUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ISendItemDataAble>() != null)
        {
            ISendItemDataAble item = collision.gameObject.GetComponent<ISendItemDataAble>();
            InvenUi.instance.GetItemDataAble(item);
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.GetComponents<Enemy>() != null && PointerEnterValue != null)
        {
            targetenemy = collision.gameObject.GetComponents<Enemy>();
            Attackdetail(targetenemy);
            attckzonecollider.gameObject.SetActive(false);
            targetenemy = null;
        }

        Debug.Log("���� �Ծ���");
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


    public GameObject attckzonecollider;

    void Attackdetail(Enemy[] targas)
    {
        Debug.Log("���� ����!!!!!!");
        if (PointerEnterValue == skillUI[0].name && skillUI[0].GetComponent<SkillState>().Cool == true)
            foreach (Enemy targa in targas)
            {
                targa.EnemyHP -= Crt;
                
                                                
                Debug.Log("�⺻���� ����");
            }
        else if (PointerEnterValue == skillUI[1].name && skillUI[1].GetComponent<SkillState>().Cool == true)
            foreach (Enemy targa in targas)
            {
                targa.EnemyHP -= Crt * 1.5f;
                
                Debug.Log("�������� ����");
            }
        else if (PointerEnterValue == skillUI[2].name && skillUI[2].GetComponent<SkillState>().Cool == true)
            foreach (Enemy targa in targas)
            {
                targa.EnemyHP -= Crt * 0.7f;
               
                Debug.Log("ū���� ����");
            }

    }


    public GameObject componentAttackZone;
    public  BoxCollider2D attackZone;
  

    public float basicAttackZone = 3;
    public float littleAttackZone = 2;
    public float bigAttackZone = 0f;
    void AttackZoneRange()
    {
        switch (SKILLS)
        {
            case SKILL.BASIC_ATTACK:
                attackZone.size = new Vector2(4, 2);
                if (PlayerForwardSprite == true)
                    attackZone.offset = new Vector2(basicAttackZone, 0);
                else
                    attackZone.offset = new Vector2(basicAttackZone * -1, 0);

                break;

            case SKILL.LITTLE_ATTACK:
                attackZone.size = new Vector2(2, 2);
                if (PlayerForwardSprite == true)
                    attackZone.offset = new Vector2(littleAttackZone, 0);
                else
                    attackZone.offset = new Vector2(littleAttackZone * -1, 0);

               
                break;
            case SKILL.BIG_ATTACK:
                attackZone.size = new Vector2(11, 2);
                attackZone.offset = new Vector2(0, 0);
               

                break;

        }




    }

    public ItemClass GetItemClass()
    {
        throw new NotImplementedException();
    }

    void Die()
    {
        //�ִϸ��̼�
    }


    void Hit()
    {
        // �ִϸ��̼�
    }

}

public enum SKILL
{ 
    BASIC_ATTACK, LITTLE_ATTACK,BIG_ATTACK
}



