using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Enemy.Bullet;
using UnityEngine;

namespace Enemy
{
    public class BossEnemy : BaseEnemy, IBossEnemy
    {
        private BossEnemy()
        {

        }

        [SerializeField] List<EnemyBullet> bullets;
        Queue<EnemyBullet> _enemyBullets = new Queue<EnemyBullet>();
        [SerializeField] private EnemyBullet enemyBullet1;
        
        private EnemyBulletController enemyBulletController;

        

        private void Awake() 
        {
            if(enemyBulletController == null)
            {
                enemyBulletController = new EnemyBulletController();    
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
            
            
        }


       

        Vector3 pos = Vector3.zero;

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
                else
                {
                    EnemyAttackFunction(100);

                    
                }
                yield return null;
            }
        }

       

        [SerializeField] private GameObject collisionTarget;

        void OnTriggerStay2D(Collider2D collision)
        {
            //TargetTowerTypeFind(collision.gameObject,true);
            
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            //TargetTowerTypeFind(collision.gameObject,false);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            TargetTowerTypeFind(collision.collider.gameObject,true);
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            TargetTowerTypeFind(collision.collider.gameObject,false);
        }



        private void TargetTowerTypeFind(GameObject targetTower,bool value)
        {
            switch(targetTower.gameObject.tag)
            {
                case "ArcherTower":
                    isFire = value;
                    collisionTarget = targetTower;
                break;
                case "FireTower":
                    isFire = value;
                    collisionTarget = targetTower;
                break;
                case "IceTower":
                    isFire = value;
                    collisionTarget = targetTower;
                break;
                case "TowerBullet":
                    isFire = value;
                    collisionTarget = targetTower;
                break;
                case "MainTower":
                    isFire = value;
                    collisionTarget = targetTower;
                break;
                default:
                break;
            }
            
        }

        private float a = 0;

        public override void EnemyAttackFunction(int damageValue)
        {
            a += Time.deltaTime * .5f;

            if (a > 1)
            {
                if(_enemyBullets.Count > 0 )
                {
                    EnemyBullet enemyBullet = enemyBulletController.GetEnemyBulletFromPool(_enemyBullets);
                    enemyBullet.EnemyBulletMovement(collisionTarget.transform);
                    Vector2 pos = transform.GetChild(0).transform.position;
                    StartCoroutine(enemyBulletController.DisableEnemyBulletAfterDelay(_enemyBullets,enemyBullet,pos,3));
                } 
               
                a = 0;
            }
        }
       
       

      

        void OnEnable()
        {
            StopCoroutine(Move());
        }
    }

}
