using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public TextMeshProUGUI playerHptext;
    public TextMeshProUGUI playerMptext;
    public TextMeshProUGUI playerAtktext;
    public TextMeshProUGUI playerEXPtext;
    public TextMeshProUGUI playerLvtext;


    int enemyCount;
   public int EnemyCount
    {
        get { return enemyCount; }
        set { enemyCount = value;
            Player.instance.EXP += 10;

        }
    }

    void Start()
    {
        PoolingManager.instance.Pop(260, 2);    
    }

    private void Update()
    {
        playerHptext.text = "Hp :" + Player.instance.Hp;
        playerMptext.text = "Mp :" + Player.instance.Mp;
        playerAtktext.text = "ATK :" + Player.instance.Crt;
        playerEXPtext.text = "EXP :" + Player.instance.EXP;
        playerLvtext.text = "LV " + Player.instance.PlayerLV;
    }


    //public void PlayerDie()
    //{
    //    if (Player.instance.Hp <= 0)
    //    { 
            
        
    //    }

    //}

    //public void GameEnd()
    //{
        


    //}

}
