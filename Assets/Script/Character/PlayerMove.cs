using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    // �÷��̾� ������ ���� �� ������ ������ ������ ���� ��

    // ������ٵ� addforse ���� �����ؼ� ������ֱ�

    [SerializeField] GameObject gameObject;
    Rigidbody2D rigidbody;
    Vector2 movePosition;
    Vector2 inputMove;
    float speed = 3f;

    //GameObject 


    private void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();

    }



    private void Update()
    {
        inputMove = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movePosition = inputMove .normalized  * speed ;

    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movePosition * Time.fixedDeltaTime);
    }

}



    //Dictionary<KeyCode, Action> playerMoveDic = new Dictionary< KeyCode, Action>();

    //Action up;
    //Action down;
    //Action right;
    //Action left;


        //PlayerWork(gameObject, rigidbody);



    // ������ �����̱� , �ڷ� �����̱� , ���� ����[��������] , �����ϰ� ���帮��
    //public void PlayerWork(GameObject gameObject, Rigidbody rigidbody)
    //{
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        transform.position = transform.position + Vector3.up;
    //        Jump(rigidbody, speed);
    //    }

    //    if (Input.GetKeyDown(KeyCode.S))
    //        transform.position = transform.position + Vector3.down;
    //    if (Input.GetKeyDown(KeyCode.D))
    //        transform.position = transform.position + Vector3.right;
    //    if (Input.GetKeyDown(KeyCode.A))
    //        transform.position = transform.position + Vector3.left;
    //}



    //public void Jump(Rigidbody rig, float spd)
    //{
    //    Vector3 vector3 = transform.position + (new Vector3(0, 3) * spd * Time.deltaTime );
    //    rig.AddForce(vector3);       
    //}

