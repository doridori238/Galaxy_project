using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rigdbody;
    Animator animator;
    SpriteRenderer spriteRenderer;
    RaycastHit2D floorhit2D;
    float nextspeed;
    Vector2 frontVec;
    Collider2D playerhit2D;
    

    void Start()
    {
        rigdbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(EnemyMove());
    }

    private void FixedUpdate()
    {
        rigdbody.velocity = new Vector2(nextspeed, 0);

        frontVec = new Vector2(rigdbody.position.x + nextspeed, 0);

        Debug.DrawRay(frontVec, Vector3.down, new Color(5, 0, 0));

        floorhit2D = Physics2D.Raycast(frontVec, Vector2.down, 2, 1 << 6);
        if (floorhit2D.collider != null)
            animator.SetBool("isWalk", true);
        else
            Turn();

        playerhit2D = Physics2D.OverlapCircle(rigdbody.position, 2f, 1 << 7);
        if (playerhit2D != null )
        {
            Debug.Log("²ô¾Ç");
            Rigidbody2D temp = playerhit2D.gameObject.GetComponent<Rigidbody2D>();
            StopCoroutine(EnemyMove());
            Attack(temp);
         
        }
        
    }

    IEnumerator EnemyMove()
    {
        nextspeed = Random.Range(-1f, 3f);

        Turn();

        yield return null; 
    }

    void Turn()
    {
        nextspeed *= -1;
        spriteRenderer.flipX = nextspeed == -1;
    }

    
    void Attack(Rigidbody2D temp)
    {
        //spriteRenderer.flipX = temp.velocity.x ==;
        animator.SetBool("isWalk", false);
        rigdbody.velocity = new Vector2(rigdbody.position.x, 0);

        animator.SetTrigger("doTouch");
        Debug.Log("²Ç~°Ý!!!");

        if (temp == null)
        {
            animator.SetBool("isWalk", true);
            StartCoroutine(EnemyMove());
        }

    }

    
}
