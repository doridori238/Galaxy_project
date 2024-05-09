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
    public float nextMove;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Vector2 overlapsizevec = new Vector2(5, 0.2f);
    Vector2 frontVec; 
    [SerializeField] float sense;
    RaycastHit2D floorhit2D;
    Collider2D playerhit2D;
    

    private void Start()
    {
        rigdbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
        Invoke("Think", 2);
    }



    private void FixedUpdate()
    {
        rigdbody.velocity = new Vector2(nextMove, rigdbody.velocity.y);

        frontVec = new Vector2(rigdbody.position.x + nextMove, rigdbody.position.y);
        Debug.DrawRay(frontVec, Vector3.left, new Color(5, 0, 0));


        floorhit2D = Physics2D.Raycast(frontVec, Vector2.down, 1, 1 << 6);
        if (floorhit2D.collider == null)
        {
            Turn();
        }


        playerhit2D = Physics2D.OverlapCircle(rigdbody.position, 2.5f, 1 << 7);
        if (playerhit2D != null)
        {
            Vector2 hitdis = playerhit2D.transform.position - transform.position;
            float degree = Mathf.Atan2(hitdis.x, hitdis.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, degree, 0);

            //nextMove = 0;

            TargetTrace();
            Debug.Log("도리");

        }




    }




    /// <summary>
    /// TargetTrace / ����
    /// </summary>
    void TargetTrace()
    {

        Vector2 hitdis = playerhit2D.transform.position - transform.position;
        float degree = Mathf.Atan2(hitdis.x, hitdis.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, degree, 0);

        // 1. 몬스터가 추격 함수에 들어오면 움직임을 멈춘다.
        // 2. 타겟 방면으로 바라본다, 스프라이트 축만 바꾸는 것도 방법일 듯.(turn 함수를 사용하는 것도 나쁘지 않은듯)
        // 3. 그리고 그 위치에서 공격 하기
        // 4. 범위에서 벗어나면 



        //animator.SetBool("isWalk", false);
        // TargetAttack();

        //if (playerhit2D.composite == null)
        //{
        //    //nextMove = Random.Range(-1, 2);
        //    Invoke("Think", 3f);
        //    Debug.Log("정상 작동");
        //}

    }



    //void TargetAttack()
    //{
    //    //animator.SetBool("isTouch",true);
    //    Debug.Log("공격");


    //    if (playerhit2D.composite == null)
    //    {
    //        //animator.SetBool("isTouch", false);
    //        TargetTrace();
    //    }


    //}


    void Think()
    {
        Debug.Log("많이 나온다");
        nextMove = Random.Range(-1, 2); //* 2;/// ���⼭ �ӵ� �����ֱ�


        animator.SetBool("isWalk", true);
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == -1;


        float nextTime = Random.Range(2f, 4f);
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
