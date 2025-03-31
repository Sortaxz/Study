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
            
            print(transform.name + "-" + transform.position);
            
            if(transform.GetChild(0).childCount < 1)
            {
                _enemyBullets = new Queue<EnemyBullet>(enemyBulletController.CreateEnemyBullets(transform.GetChild(0).transform,10));
            }
            else if(transform.GetChild(0).childCount > 1)
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
                    this.EnemyAttackFunction(100);

                    
                }
                yield return null;
            }
        }

        private void FindTargetDistance(GameObject target)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);   
            if(distance <= .5f)
            {

                isFire = true;
            }
        }


        void OnTriggerStay2D(Collider2D collision)
        {
            TargetTowerTypeFind(collision.gameObject,true);
            
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            TargetTowerTypeFind(collision.gameObject,false);
        }


        private void TargetTowerTypeFind(GameObject targetTower,bool value)
        {
            switch(targetTower.tag)
            {
                case "ArcherTower":
                    isFire = value;
                break;
                case "FireTower":
                    isFire = value;
                break;
                case "IceTower":
                    isFire = value;
                break;
                case "TowerBullet":
                    isFire = value;
                break;
                case "MainTower":
                    isFire = value;
                break;
                default:
                break;
            }
        }

        private float a = 0;

        public override void EnemyAttackFunction(int damageValue)
        {
            print("attak yapiyor");
            a += Time.deltaTime * .5f;

            if (a > 1)
            {
                if(_enemyBullets.Count > 0 )
                {
                    EnemyBullet enemyBullet = enemyBulletController.GetEnemyBulletFromPool(_enemyBullets);
                    StartCoroutine(enemyBulletController.DisableEnemyBulletAfterDelay(_enemyBullets,enemyBullet,3));
                } 
                else
                {
                    print("0");
                }
                a = 0;
            }
        }
       
       

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                foreach (var item in _enemyBullets)
                {
                    print(item);
                }
            }
        }


        void OnEnable()
        {
            StopCoroutine(Move());
        }
    }

}
