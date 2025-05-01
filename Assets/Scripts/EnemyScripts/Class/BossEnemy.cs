using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Enemy.Bullet;
using Enemy.UIController;
using EnemyCoin.Factory;
using UnityEngine;

namespace Enemy
{
    public class BossEnemy : BaseEnemy, IBossEnemy
    {

        [SerializeField] List<EnemyBullet> bullets;
        

        private void Awake() 
        {
            if(enemyBulletController == null)
            {
                enemyBulletController = new EnemyBulletController();    
            }

            if(enemyUIController == null)
            {
                enemyUIController = GetComponent<EnemyUIController>();   
            }
            
            if(transform.GetChild(0).childCount < 1)
            {
                _enemyBullets = new Queue<EnemyBullet>(enemyBulletController.CreateEnemyBullets(transform.GetChild(0).transform,1));
            }
            else if(transform.GetChild(0).childCount >= 1)
            {
                _enemyBullets = new Queue<EnemyBullet>(enemyBulletController.GetEnemyBulletFromEnemyBulletsList(transform.GetChild(0)));
                bullets = _enemyBullets.ToList();
                
                
            }

            botyGold = Random.Range(0,100);            
            
            if(enemyCoinFactory == null)
            {
                enemyCoinFactory = new EnemyCoinFactory();
            }
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.U))
            {
                EnemyDestroy();
            }
        }



    }

}
