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

    public Animator playerAnimator;

    public Image hpImage;


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
    float maxhp = 300;
    public float Hp
    {
        get { return hp; }
        set { hp = value;

            if (Hp <= 0)
            {
                Die();
            }
                
        }
    }

    float mp = 0;
    float maxMp = 500;

    public float Mp
    {
        get { return mp; }
        set { mp = value;
            if (Mp >= maxMp)
            {
                 PlayerLV += 1;
                 
            }
        }
    }


    float exp = 0;
    float maxexp = 100;
    public float EXP
    {
        get { return exp; }
        set { exp = value;
            if (EXP >= maxexp)
            {
                PlayerLV += 1;
                EXP = exp;
            }

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
        attackZone = attackZone.GetComponent<BoxCollider2D>();
        playerAnimator= GetComponent<Animator>();
       
        //particleBasictemp = Instantiate(particleBasicAttack, attackZone.transform);
        //particleRittletemp = Instantiate(particleLittleAttack, attackZone.transform); 
        //particlleBigtemp = Instantiate(particleBigAttack, attackZone.transform);
       
        playerattacksword.SetActive(false);
        playerBasicsword.SetActive(true);
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

        hpImage.fillAmount =  Hp/maxhp;



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
            Debug.Log("이벤트 돈다");
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
            playerAnimator.SetTrigger("Attackani");
            Attackdetail(targetenemy);
            attckzonecollider.gameObject.SetActive(false);
            playerattacksword.SetActive(true);
            playerBasicsword.SetActive(false);
            targetenemy = null;
        }

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


    public GameObject attckzonecollider;
    public GameObject particleBasicAttack;
    GameObject particleBasictemp;
    public GameObject particleLittleAttack;
    GameObject particleRittletemp;
    public GameObject particleBigAttack;
    GameObject particlleBigtemp;
    void Attackdetail(Enemy[] targas)
    {
        Debug.Log("젤리 공격!!!!!!");
        
        if (PointerEnterValue == skillUI[0].name && skillUI[0].GetComponent<SkillState>().Cool == true)
        {
            foreach (Enemy targa in targas)
            {
                particleBasictemp = Instantiate(particleBasicAttack, targa.transform);
                particleBasictemp.SetActive(true);
                targa.EnemyHP -= Crt;
                playerattacksword.SetActive(false);
                playerBasicsword.SetActive(true);
                Debug.Log("기본공격 성공");
            }
        }
        else if (PointerEnterValue == skillUI[1].name && skillUI[1].GetComponent<SkillState>().Cool == true)
        {
            foreach (Enemy targa in targas)
            {
                particleRittletemp = Instantiate(particleLittleAttack, targa.transform);
                particleRittletemp.SetActive(true);
                targa.EnemyHP -= Crt * 1.5f;
                playerattacksword.SetActive(false);
                playerBasicsword.SetActive(true);
                Debug.Log("작은공격 성공");
            }

        }
        else if (PointerEnterValue == skillUI[2].name && skillUI[2].GetComponent<SkillState>().Cool == true)
        { 
            foreach (Enemy targa in targas)
            {
                particlleBigtemp = Instantiate(particleBigAttack, targa.transform);
                particlleBigtemp.SetActive(true);
                targa.EnemyHP -= Crt * 0.7f;
                playerattacksword.SetActive(false);
                playerBasicsword.SetActive(true);
                Debug.Log("큰공격 성공");
            }
        
        }

    }


    //public GameObject componentAttackZone;
    public  BoxCollider2D attackZone;
    public GameObject playerattacksword;
    public GameObject playerBasicsword;
  

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
                {
                    attackZone.offset = new Vector2(basicAttackZone, 0);
                    playerattacksword.GetComponent<SpriteRenderer>().flipX = true;
                    playerBasicsword.GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                { 
                    attackZone.offset = new Vector2(basicAttackZone * -1, 0);
                    playerattacksword.GetComponent<SpriteRenderer>().flipX = false;
                    playerBasicsword.GetComponent<SpriteRenderer>().flipX = false;
                }
                break;

            case SKILL.LITTLE_ATTACK:
                attackZone.size = new Vector2(2, 2);
                if (PlayerForwardSprite == true)
                {
                    attackZone.offset = new Vector2(littleAttackZone, 0);
                    playerattacksword.GetComponent<SpriteRenderer>().flipX = true;
                    playerBasicsword.GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                { 
                    attackZone.offset = new Vector2(littleAttackZone * -1, 0);
                    playerattacksword.GetComponent<SpriteRenderer>().flipX = false;
                    playerBasicsword.GetComponent<SpriteRenderer>().flipX = false;
                }

               
                break;
            case SKILL.BIG_ATTACK:
                attackZone.size = new Vector2(11, 2);
                attackZone.offset = new Vector2(0, 0);
                playerattacksword.SetActive(false);
                playerBasicsword.SetActive(false);

                break;

        }

    }

    public ItemClass GetItemClass()
    {
        throw new NotImplementedException();
    }

    public GameObject dieparticle;
    GameObject diepaticletemp;
   public  void Die()
    {
        diepaticletemp = Instantiate(dieparticle);
        diepaticletemp.SetActive(true);
        //애니메이션
    }


    public void Hit()
    {
        playerAnimator.SetTrigger("Hitani");
    }

}

public enum SKILL
{ 
    BASIC_ATTACK, LITTLE_ATTACK,BIG_ATTACK
}



