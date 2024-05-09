using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager instance = null;
    public GameObject targetPrafab;
    public Queue<GameObject> pool = new Queue<GameObject>();


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Init();
    }

    public void Init()
    {
        for (int i = 0; i<10;i++)
        {
            pool.Enqueue(Instantiate(targetPrafab));
            pool.Peek().gameObject.SetActive(false);

        }

    }


    public void Pop()
    { 
        GameObject popobj= pool.Dequeue();
        popobj.SetActive(true);

    }

    public void ReturnPool(GameObject returnObj)
    {
        returnObj.SetActive(false);
        pool.Enqueue(returnObj);
    }

}
