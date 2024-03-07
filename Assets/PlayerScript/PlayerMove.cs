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

    // Ű�ڵ带 ��ǲ �ý��ۿ� ���� �������ֱ� ��������Ʈ�� ���ؼ� �����ϰų� ���ֱ�
    //public void Start()
    //{
    //    playerMoveDic.Add(KeyCode.W, up = () => { transform.position = transform.position + Vector3.up; });
    //    playerMoveDic.Add(KeyCode.S, down = () => { transform.position = transform.position + Vector3.down; });
    //    playerMoveDic.Add(KeyCode.D, right = () => { transform.position = transform.position + Vector3.right; });
    //    playerMoveDic.Add(KeyCode.A, left = () => { transform.position = transform.position + Vector3.left; });
    //}




    // ������ �����̱� , �ڷ� �����̱� , ���� ����[��������] , �����ϰ� ���帮��
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
