using System;
using UnityEngine;
using UnityEngine.UIElements;
using static InterfaceManager;
public class Player : MonoBehaviour,ISendItemDataAble
{ 
    public FixedJoystick joystick = null;
    public RectTransform handle = null;

    Rigidbody2D playerRd;   
    float maxspeed = 3f;
    Vector2 hMoveVelocity;
    
    float jumpForce = 5;
    
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

    }



    private void FixedUpdate()
    {

        playerRd.AddForce(Vector2.right*hjoy, ForceMode2D.Impulse);

        if (vjoy == 1)
            playerRd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);


        else if (playerRd.velocity.x > maxspeed)
            playerRd.velocity = new Vector2(maxspeed, playerRd.velocity.y);


        else if (playerRd.velocity.x < maxspeed * (-1))
            playerRd.velocity = new Vector2(maxspeed * (-1), playerRd.velocity.y);


        else if(playerRd.velocity.y > maxspeed*2)
            playerRd.velocity = new Vector2(playerRd.velocity.x, maxspeed * 2);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item currnetItem = collision.GetComponent<Item>();

        Debug.Log(currnetItem.itemname);
    }

    public Item OnSendItemDataAble(Item item)
    {
        throw new NotImplementedException();
    }
}


