using System.Collections;
using System.Collections.Generic;
using Enemy.Bullet;
using UnityEngine;

namespace Enemy
{
    public class MeleeEnemy : BaseEnemy,IMeleeEnemy
    {
        Vector3 pos = Vector3.zero;
        protected EnemyBulletController enemyBulletController;

       


        public void Movement(Vector3 target)
        {
            transform.position = Vector3.MoveTowards(transform.position,target, Time.deltaTime * 2);
        }

        public void SetTargetMovement(Vector3 target)
        {
            pos = target;
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (transform.position != pos)
            {
                if(!isFire)
                {
                    Movement(pos);
                }
                yield return null;
            }
        }

        void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("TowerBullet"))
            {
                isFire = true;
            }
            TargetTowerTypeFind(collision.gameObject);
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("TowerBullet"))
            {
                isFire = false;
            }
        }


        private void TargetTowerTypeFind(GameObject targetTower)
        {
            switch(targetTower.tag)
            {
                case "ArcherTower":
                    print("ArcherTower");
                    isFire = true;
                break;
                case "FireTower":
                    print("FireTower");
                    isFire = true;
                break;
                case "IceTower":
                    print("IceTower");
                    isFire = true;
                break;
            }
        }

        
    }

}
