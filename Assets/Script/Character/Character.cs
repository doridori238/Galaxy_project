using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //HP : HP �ִ�ġ
    //MP : MP �ִ�ġ
    //CRT : ġ��Ÿ Ȯ��
    //STR : ���ݷ�(����)
    //DEX : ���ݷ�(����) + �̵��ӵ�

    public float HP;
    public float MaxHP;
    public float CRT;
    public float STR;
    public float DEX;

    public virtual void Stat()
    {
        

    }


}


//public class PlayerCharacter : Character
//{
//    public override void Stat()
//    {
        

//    }

//}


//public class NonCharacter : Character
//{
//    public override void Stat()
//    {


//    }

//}
