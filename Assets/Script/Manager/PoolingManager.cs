using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEditor.PlayerSettings;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }

    public GameObject targetPrafab;
    public int initSize;
    public Queue<GameObject> pool = new Queue<GameObject>();

    private void Start()
    {
        pool = new Queue<GameObject>();
        AddPool(initSize);
    }


    

    public void AddPool(int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject copyObject = null;
            copyObject = Instantiate(targetPrafab);
            copyObject.SetActive(false);
            pool.Enqueue(copyObject);
        }
    }



    public void Pop(int randomx, int randomy)
    {
        if (pool.Count <= 0)
        {
            AddPool(initSize / 3);
        }
        GameObject popobj= pool.Dequeue();
        popobj.transform.position = new Vector3(Random.Range(0, randomx), Random.Range(1, randomy), 0);
        popobj.SetActive(true);

    }

    public void ReturnPool(GameObject returnObj)
    {
        returnObj.SetActive(false);
        pool.Enqueue(returnObj);
    }

}