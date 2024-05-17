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
            if (EnemyHP < 1)
                Die();
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
    }

    private void FixedUpdate()
    {
        rigdbody.velocity = new Vector2(nextspeed, 0);

        frontVec = new Vector2(rigdbody.position.x + nextspeed,rigdbody.position.y);

        Debug.DrawRay(frontVec, Vector3.down, new Color(2, 0, 0));

        floorhit2D = Physics2D.Raycast(frontVec, Vector2.down, 2, 1 << 6);
        if (floorhit2D.collider == null)
        { 
             Turn();
        }


        playerhit2D = Physics2D.OverlapCircle(rigdbody.position, 2.5f, 1 << 7);
        if (playerhit2D != null)
        {
            if (playerhit2D.Distance(Monstercoll).distance < 1.5)
            {
                StopCoroutine(EnemyMove());
                nextspeed = 0;
                frontVec = new Vector2(rigdbody.position.x + nextspeed, 0);
                Player targetHp = Player.instance;

                //Debug.Log(targetHp.Hp);

                
                Attack(targetHp);

            }

        }

    }


    IEnumerator EnemyMove()
    {
        Debug.Log("들어왔다!");
        animator.SetBool("isWalk", true);

        nextspeed = Random.Range(-1, 2);

        if (nextspeed == 0)
        {
            nextspeed = 1;

        }
        else if (nextspeed < 0)
        { spriteRenderer.flipX = true; }
        else if (nextspeed > 0)
        { spriteRenderer.flipX = false; }

        yield return null;
    }
   

    void Turn()
    {
        nextspeed *= -1;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }


    void Attack(Player targetHp)
    {
        //Debug.Log(targetHp.Hp + "Hp");
        animator.SetBool("isWalk", false);
        //rigdbody.velocity = new Vector2(rigdbody.position.x, 0);
        animator.SetTrigger("doTouch");
        //targetHp.Hp -= Atk;

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

    void Die()
    {
        gameObject.SetActive(false);
    }


    void Hit()
    { 
        // hp를 깍아준당
    
    }

}
