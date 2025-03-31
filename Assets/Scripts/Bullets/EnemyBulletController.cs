using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Bullet
{
    [Serializable]
    public class EnemyBulletController 
    {
        
        
        public Queue<EnemyBullet> CreateEnemyBullets(Transform enemyBulletParent,int enemyBulletCount)
        {
            Queue<EnemyBullet> enemyBullets = new Queue<EnemyBullet>();
            EnemyBullet enemyBulletPrefab = Resources.Load<EnemyBullet>("EnemyPrefabs/EnemyBulletPrefabs/EnemyBullet");
            int count = enemyBulletCount - enemyBulletParent.childCount;
            for (int i = 0; i < count; i++)
            {
                EnemyBullet enemyBullet = GameObject.Instantiate(enemyBulletPrefab,enemyBulletParent);
                enemyBullet.name = enemyBullet.name.Replace("(Clone)","");
                enemyBullet.name += $"{i}";
                enemyBullet.gameObject.SetActive(false);
                enemyBullets.Enqueue(enemyBullet);
            }
            return enemyBullets;
        }

        public Queue<EnemyBullet> GetEnemyBulletFromEnemyBulletsList(Transform enemyBulletParent)
        {
            Queue<EnemyBullet> enemyBullets = new Queue<EnemyBullet>();
            for (int i = 0; i < enemyBulletParent.childCount; i++)
            {
                EnemyBullet enemyBullet = enemyBulletParent.GetChild(i).GetComponent<EnemyBullet>();
                enemyBullets.Enqueue(enemyBullet);
            }
            return enemyBullets;
        }

        internal EnemyBullet GetEnemyBulletFromPool(Queue<EnemyBullet> enemyBullets)
        {
        
            if(enemyBullets.Count > 0)
            {
                EnemyBullet enemyBullet = enemyBullets.Dequeue();
                enemyBullet.gameObject.SetActive(true);
                return enemyBullet;
                
            } 

            return null;
        
        }

        public void ReturnEnemyBulletToPool(Queue<EnemyBullet> enemyBullets,EnemyBullet enemyBullet)
        {
            enemyBullet.gameObject.SetActive(false);
            enemyBullets.Enqueue(enemyBullet);
        }

        internal IEnumerator DisableEnemyBulletAfterDelay(Queue<EnemyBullet> enemyBullets,EnemyBullet enemyBullet,float delay)
        {
            yield return new WaitForSeconds(delay);
            Debug.Log("havuza geri dönüyor");
            ReturnEnemyBulletToPool(enemyBullets,enemyBullet);
        }

    }
}
