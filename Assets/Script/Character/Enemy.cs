using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float enemyHp;
    [SerializeField] float enemyMaxHp;
    [SerializeField] float enemyCRT;
    [SerializeField] float enemyATK;
    [SerializeField] float enemySpeed;



    Rigidbody2D rigdbody;
    public int nextMove;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Vector2 overlapsizevec = new Vector2(5, 0.2f);
    Vector2 frontVec;
    Collider2D targethit;
    Collider2D attackzone;
    Collider2D thiscollider;


    private void Start()
    {
        rigdbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        thiscollider = GetComponent<Collider2D>();
        Invoke("Think", 5);
    }



    private void FixedUpdate()
    {
        rigdbody.velocity = new Vector2(nextMove, rigdbody.velocity.y);

        MoveEnemy();
    }



    void MoveEnemy()
    { 
        frontVec = new Vector2(rigdbody.position.x + nextMove, rigdbody.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D floorhit2D = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Floor"));
        if (floorhit2D.collider == null)
        {
            Turn();
        }
   
    }



    /// <summary>
    /// TargetSense / 감지
    /// </summary>
    void TargetSense()
    {

        targethit = Physics2D.OverlapBox(frontVec, overlapsizevec, 0, LayerMask.GetMask("Player"));
     
        if (targethit != null)
            TargetTrace();
        else
            Turn();

    }



    /// <summary>
    /// TargetTrace / 추적
    /// </summary>
    void TargetTrace()
    {

        // player 추적
        attackzone = Physics2D.OverlapCircle(frontVec, 1.5f);
        if (attackzone != null)
            TargetAttack();
        else
            TargetSense();

    }



    void TargetAttack()
    {


    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(rigdbody.position, overlapsizevec);
    }



    void Think()
    {
        nextMove = Random.Range(-1, 2);


        animator.SetBool("isWalk", true);
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == -1;


        float nextTime = Random.Range(2f, 5f);
        Invoke("Think", nextTime);

    }



    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == -1;


        CancelInvoke();
        Invoke("Think", 2);

    }


    void Die()
    { 
    
    
    }
   

}
