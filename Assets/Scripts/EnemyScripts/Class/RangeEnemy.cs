using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Enemy.Bullet;
using UnityEngine;

namespace Enemy
{
    public class RangeEnemy : BaseEnemy,IRangeEnemy
    {


        [SerializeField] List<EnemyBullet> bullets;
       


        private void Awake()
        {
            if (enemyBulletController == null)
            {
                enemyBulletController = new EnemyBulletController();
            }


            if (transform.GetChild(0).childCount < 1)
            {
                _enemyBullets = new Queue<EnemyBullet>(enemyBulletController.CreateEnemyBullets(transform.GetChild(0).transform, 1));
            }
            else if (transform.GetChild(0).childCount > 1)
            {
                _enemyBullets = new Queue<EnemyBullet>(enemyBulletController.GetEnemyBulletFromEnemyBulletsList(transform.GetChild(0)));
                bullets = _enemyBullets.ToList();


            }


        }





        

       
    }

}
