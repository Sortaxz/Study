using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 10;
    
    private Queue<GameObject> pool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        if(pool.Count > 0)
        {
            GameObject obje = pool.Dequeue();
            obje.SetActive(true);
            return obje;
        }
        else
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(true);
            return obj;
        }
    }


    public void ReturnPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

}
