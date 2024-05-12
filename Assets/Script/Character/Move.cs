using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

public class Move : MonoBehaviour
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
    
    int lv;
    public int LV
    {
        get{ return lv; }
        set { lv = value; }
    
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

        frontVec = new Vector2(rigdbody.position.x + nextspeed, 0);

        Debug.DrawRay(frontVec, Vector3.down, new Color(5, 0, 0));

        floorhit2D = Physics2D.Raycast(frontVec, Vector2.down, 2, 1 << 6);
        if (floorhit2D.collider == null)
            Turn();
        

        playerhit2D = Physics2D.OverlapCircle(rigdbody.position, 3f, 1 << 7);
        if (playerhit2D != null)
        {
            if (playerhit2D.Distance(Monstercoll).distance < 2)
            {
                nextspeed = 0;
                frontVec = new Vector2(rigdbody.position.x + nextspeed, 0);
                StopCoroutine(EnemyMove());
                Debug.Log("莖學");
                Attack();

            }
            
        }
      
    }


    IEnumerator EnemyMove()
    {
        Debug.Log("菟橫諮棻!");
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

    
    void Attack()
    {
        
        animator.SetBool("isWalk", false);
        rigdbody.velocity = new Vector2(rigdbody.position.x, 0);

        animator.SetTrigger("doTouch");
     
    }


    void StartAttackPaticleEvnt()
    {
        Debug.Log("笞~問!!!");
        partiecle.SetActive(true);
    }


    void EndAttackPaticleEvnt()
    {
        Debug.Log("笞~問 部!!!");
        partiecle.SetActive(false);
        StartCoroutine(EnemyMove());
        Turn();
    }


}
