using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Bullet
{
    public class EnemyBullet : BaseEnemyBullet
    {
        public delegate void  b();
        public b _b;
        void Awake()
        {
        }

        public void EnemyDestory()
        {
            StartCoroutine(StartEnemyBulletDestoryTime());
        }

        public IEnumerator StartEnemyBulletDestoryTime()
        {
            yield return new WaitForSeconds(3);
            gameObject.SetActive(false);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("ArcherTower"))
            {
                gameObject.SetActive(false);
            }
            if(collision.gameObject.CompareTag("FireTower"))
            {
                gameObject.SetActive(false);

            }
            if(collision.gameObject.CompareTag("IceTower"))
            {
                gameObject.SetActive(false);

            }
        }

    }
}

