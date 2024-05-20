using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public GameObject Enemytran;
    Rigidbody2D rigdbody;
    Animator animator;
    SpriteRenderer spriteRenderer;
    RaycastHit2D floorhit2D;
    int nextspeed;
    Vector2 frontVec;
    Collider2D playerhit2D;
    Collider2D Monstercoll;
    public GameObject attackparti;
    GameObject partiecle;
    [SerializeField] float atk = 5;


    public GameObject enemyattackzone;
    public BoxCollider2D boxCollider2D;
    public float collideroffsetsettingX;
    public float collideroffsetsettingY;

    GameObject dieParticle;

    public float Atk
    {
        get { return atk; }
        set { atk = value * LV; }

    }

    [SerializeField] int lv = 1;
    public int LV
    {
        get { return lv; }
        set { lv = value; }
    }

    [SerializeField] float enemyHp = 50;
    public float EnemyHP
    {
        get { return enemyHp; }
        set {
            enemyHp = value;
            Debug.Log(EnemyHP + "젤리 목숨");
            Hit();
            if (EnemyHP < 1)
                Die();

        }

    }

    public bool EnemyForward
    {
        get { return spriteRenderer.flipX; }
        set { spriteRenderer.flipX = value; 
        
        
        
        }
    }

    void Start()
    {
        rigdbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Monstercoll = GetComponent<Collider2D>();
        StartCoroutine(EnemyMove());
        partiecle = Instantiate(attackparti, Enemytran.transform);
        hitParticle = Instantiate(enemyHitparticle, Enemytran.transform);
        dieParticle = Instantiate(die, Enemytran.transform);

    }


    private void FixedUpdate()
    {
        rigdbody.velocity = new Vector2(nextspeed, 0);

        frontVec = new Vector2(rigdbody.position.x + nextspeed, rigdbody.position.y);

        Debug.DrawRay(frontVec, Vector3.down, new Color(2, 0, 0));

        floorhit2D = Physics2D.Raycast(frontVec, Vector2.down, 2, 1 << 6);
        if (floorhit2D.collider == null)
        {
            Turn();
        }


        playerhit2D = Physics2D.OverlapCircle(rigdbody.position, 1.5f, 1 << 7);
        if (playerhit2D != null)
        {
            if (playerhit2D.Distance(Monstercoll).distance < 0.5f)
            {
                StopCoroutine(EnemyMove());
                nextspeed = 0;
                frontVec = new Vector2(rigdbody.position.x + nextspeed, 0);
                enemyattackzone.gameObject.SetActive(true);
                //Attack(Player.instance);

            }
        }
      
    }

        IEnumerator EnemyMove()
    {
        Debug.Log("들어왔다!");
        animator.SetBool("isWalk", true);

        nextspeed = Random.Range(-2, 2);

        if (nextspeed == 0)
        {
            nextspeed = 1;

        }
        else if (nextspeed < 0)
        {
            spriteRenderer.flipX = true;
          
        }
        else if (nextspeed > 0)
        {
            spriteRenderer.flipX = false;
           
        }

        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {

            Attack(Player.instance);

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Turn();
        }
        
    }

    void Turn()
    {
        nextspeed *= -1;
        spriteRenderer.flipX = !spriteRenderer.flipX;
       
    }


    void Attack(Player targetHp)
    {
        
        animator.SetBool("isWalk", false);
       
        animator.SetTrigger("doTouch");
        targetHp.Hit();
        enemyattackzone.SetActive(false);

    }


    void StartAttackPaticleEvnt()
    {

        Debug.Log("꽁~격!!!");
        partiecle.SetActive(true);
        Player.instance.Hp -= Atk;

    }


    void EndAttackPaticleEvnt()
    {
        Debug.Log("꽁~격 끝!!!");
        partiecle.SetActive(false);
        StartCoroutine(EnemyMove());
        Turn();
    }

    public GameObject die;
    void Die()
    {
        die.SetActive(true);
        DropItem();
        PoolingManager.instance.ReturnPool(gameObject);
    }

    public GameObject enemyHitparticle;
    GameObject hitParticle;

    void Hit()
    {
        hitParticle.SetActive(true);
    }

    public ItemDropList dropItem;
    public void DropItem()
    {
        GameObject dropPrafab = dropItem[Random.Range(0, dropItem.Count)];
        Instantiate(dropPrafab, transform.position + new Vector3(0,0,1), transform.rotation);
    }

}
