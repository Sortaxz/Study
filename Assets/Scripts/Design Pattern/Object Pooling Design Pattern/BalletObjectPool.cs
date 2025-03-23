using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPoolingDesignPattern
{
    public class BalletObjectPool : MonoBehaviour
    {
        private static Queue<GameObject> bullets;
        
        static BalletObjectPool()
        {
            bullets = new Queue<GameObject>();
        }

        public static void AddBullet(GameObject bullet)
        {
            bullets.Enqueue(bullet);
            
        }
        public static GameObject GetBullet()
        {
            GameObject bullet = bullets.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }

        public static void ReturnBullet(GameObject bullet)
        {
            bullet.SetActive(false);
            bullets.Enqueue(bullet);
        }

    }

}
