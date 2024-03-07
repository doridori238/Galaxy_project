using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    // 플레이어 움직임 구현 및 움직임 전략도 나쁘지 않을 듯

    // 리지드바디 addforse 연결 생각해서 만들어주기

    [SerializeField] GameObject gameObject;
    [SerializeField] Rigidbody rigidbody;
    float speed = 10f;
   
    Dictionary<KeyCode, Action> playerMoveDic = new Dictionary< KeyCode, Action>();

    Action up;
    Action down;
    Action right;
    Action left;

    private void LateUpdate()
    {
        PlayerWork(gameObject, rigidbody);
        
    }

    // 키코드를 인풋 시스템에 같이 연결해주기 델리게이트를 통해서 연결하거나 해주기
    //public void Start()
    //{
    //    playerMoveDic.Add(KeyCode.W, up = () => { transform.position = transform.position + Vector3.up; });
    //    playerMoveDic.Add(KeyCode.S, down = () => { transform.position = transform.position + Vector3.down; });
    //    playerMoveDic.Add(KeyCode.D, right = () => { transform.position = transform.position + Vector3.right; });
    //    playerMoveDic.Add(KeyCode.A, left = () => { transform.position = transform.position + Vector3.left; });
    //}




    // 앞으로 움직이기 , 뒤로 움직이기 , 위로 점프[더블점프] , 납작하게 업드리기
    public void PlayerWork(GameObject gameObject, Rigidbody rigidbody)
    {
        //if (Input.GetKeyDown(KeyCode.W))





        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = transform.position + Vector3.up;
            Jump(rigidbody, speed);
        }

        if (Input.GetKeyDown(KeyCode.S))
            transform.position = transform.position + Vector3.down;
        if (Input.GetKeyDown(KeyCode.D))
            transform.position = transform.position + Vector3.right;
        if (Input.GetKeyDown(KeyCode.A))
            transform.position = transform.position + Vector3.left;
    }



    public void Jump(Rigidbody rig, float spd)
    {
        Vector3 vector3 = transform.position + (new Vector3(0, 3) * spd * Time.deltaTime );
        rig.AddForce(vector3);       
    }





}
