using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum stateMove
{ 
  IDLE,
  MOVE,
  ATTACK
}


public class StateMove : MonoBehaviour
{
    Rigidbody2D rigdbody;
    Animator animator;
    SpriteRenderer spriteRenderer;
    RaycastHit2D floorhit2D;
    float nextspeed;
    Vector2 frontVec;
    Collider2D playerhit2D;

    stateMove stateMove;
    void Start()
    {
        rigdbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        stateMove = stateMove.IDLE;
    }

    private void FixedUpdate()
    {
        rigdbody.velocity = new Vector2(nextspeed, 0);
       
        
        
        switch (stateMove)
        {

            case stateMove.IDLE:

                break;
            case stateMove.MOVE:

                break;
            case stateMove.ATTACK:

                break;

        }

    }

    
}
