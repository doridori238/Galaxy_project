using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //HP : HP 최대치
    //MP : MP 최대치
    //CRT : 치명타 확률
    //STR : 공격력(대폭)
    //DEX : 공격력(소폭) + 이동속도

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
