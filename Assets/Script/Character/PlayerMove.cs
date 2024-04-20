using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class PlayerMove : MonoBehaviour
{ 
    public FixedJoystick joystick = null;
    public RectTransform handle = null;

    Rigidbody2D playerRd;   
    float maxspeed = 3f;
    Vector2 hMoveVelocity;
    
    float hjoy;
    float vjoy;

    private void Start()
    {
        playerRd = GetComponent<Rigidbody2D>();   
    }


    private void Update()
    {
        hjoy = joystick.Horizontal;
        vjoy = joystick.Vertical;

        //joystick.

        Vector2 horizonMove = new Vector2(hjoy, vjoy);
        hMoveVelocity = horizonMove.normalized * maxspeed;

        //if (Input.GetMouseButton(0))
        //{
        //    playerRd.AddForce(Vector2.up*10 ,ForceMode2D.Force);
        //}

        //if (vjoy == AxisOptions.Vertical)
        //{ }
       
        
    }


   


    private void FixedUpdate()
    {
        playerRd.MovePosition(playerRd.position + hMoveVelocity * Time.fixedDeltaTime); 
    }






}


