using Enemy.Bullet;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Enemy.UIController;
using EnemyCoin.Factory;
using UnityEngine.UI;
using Enemys.Data;

namespace Enemy
{
    public abstract class BaseEnemy :MonoBehaviour
    {

        protected GameObject target;

        [SerializeField] protected EnemyUIController enemyUIController;
        protected EnemyBulletController enemyBulletController;


        protected Queue<EnemyBullet> _enemyBullets = new Queue<EnemyBullet>();
        [SerializeField] protected EnemyBullet enemyBullet1;
        
        protected EnemyCoinFactory enemyCoinFactory;

        protected SpriteRenderer enemyImage;

        protected Vector3 pos;

        [SerializeField] protected string _enemyName;
        public string EnemyName => _enemyName;

        [SerializeField] protected float _enemyHealt;
        public float EnemyHealt => _enemyHealt;
        
        protected float _enemyMaxHealt;
        public float MaxEnemyMaxHealt => _enemyMaxHealt;

        [SerializeField] protected float _enemySpeed;
        public float EnemySpeed => _enemySpeed;

        protected float _enemyMaxSpeed;
        public float EnemyMaxSpeed => _enemyMaxSpeed;

        [SerializeField] protected float _enemyAttack;
        public float EnemyAttack {get {return _enemyAttack;} set {_enemyAttack = value;} }

        protected float _enemyMaxAttack;
        public float MaxEnemyMaxAttack => _enemyMaxAttack;


        [SerializeField] protected int _enemyShield;
        public int EnemyShield => _enemyShield;

        protected int _enemyMaxShield;
        public int MaxEnemyMaxShield => _enemyMaxShield;


        [SerializeField] protected float _enemyDamage;
        public float EnemyDamage => _enemyDamage;

        protected int _enemyMaxDamage;
        public int MaxEnemyMaxDamage => _enemyMaxDamage;



        [SerializeField] protected int _enemyDefense;
        public int EnemyDefense => _enemyDefense;

        private int _enemyMaxDefense;
        public int EnemyMaxDefense => _enemyMaxDefense;            

        [SerializeField] protected int botyGold; 

        [SerializeField] protected bool isDead;
        

        [SerializeField] protected bool isFire;
        public bool IsFire => isFire;

        [SerializeField] protected bool isStop = false;
        public bool IsStop {get {return isStop;} set {isStop = value;}} 

        [SerializeField] protected bool isPause = false;
        public bool IsPause {get {return isPause;} set {isPause = value;}}

        void Awake()
        {
            
        }

        

        public void SetEnemyName(string name,int index)
        {
            transform.name = name.Replace("(Clone)","");
            transform.name = transform.name.Replace("0","");
            transform.name += index.ToString();
            _enemyName = transform.name;
        }
        

        #region  Enemy Healt

        public virtual void SetEnemyHealt(float healt, float maxHealt)
        {
            _enemyHealt = healt;
        }

        public virtual void EnemyHealtIncrease(float healt)
        { 
            if(_enemyHealt < _enemyMaxHealt)
            {
                _enemyHealt += healt;
            }
            else
            {
                _enemyHealt = _enemyMaxHealt;
            }
            enemyUIController.HealtBarValueIncrease(_enemyHealt);
        }

        public virtual void EnemyHealtReduction(float value)
        {
            if(_enemyHealt > 0)
            {
                _enemyHealt -= value;
            }
            else
            {
                EnemyDestroy();
                _enemyHealt = 0;
            }
            enemyUIController.HealtBarValueReduction(_enemyHealt);
        }

        #endregion



        #region  Enemy Speed
    
        public virtual void SetEnemySpeed(float speed,float maxSpeed)
        {
            _enemySpeed = speed;
            _enemyMaxSpeed = maxSpeed;
        }

        public virtual void EnemySpeedIncrease(int speedValue)
        {
            if(_enemySpeed < _enemyMaxSpeed)
            {
                _enemySpeed += speedValue;
            }
            else
            {
                _enemySpeed = _enemyMaxShield;
                return;
            }
        }

        public virtual void EnemySpeedReduction(int value)
        {
            if(_enemySpeed > 0)
            {
                _enemySpeed -= value;
            }
            else
            {
                _enemySpeed = 0;
                return;
            }
        }

        #endregion



        #region  Enemy Damage
    
        public virtual void SetEnemyDamage(int damage,int maxDamage)
        {
            _enemyDamage = damage;
            _enemyMaxDamage = maxDamage;
        }

        public virtual void EnemyDamageIncrease(int damageValue)
        {
            if(_enemyDamage < _enemyMaxDamage)
            {
                _enemyDamage += damageValue;
            }
            else
            {
                _enemyDamage = _enemyMaxDamage;
                return;
            }
        }

        public virtual void EnemyDamageReduction(int value)
        {
            if(_enemyDamage > 0)
            {
                _enemyDamage -= value;
            }
            else
            {
                _enemyDamage = 0;
                return;
            }
        }

        #endregion

        

        #region  Enemy Shield
    
        public virtual void SetEnemyShield(int shield,int maxShield)
        {
            _enemyShield = shield;
            _enemyMaxShield = maxShield;
        }

        public virtual void EnemyShieldIncrease(int shieldValue)
        {
            if(_enemyShield < _enemyMaxShield)
            {
                _enemyShield += shieldValue;
            }
            else
            {
                _enemyShield = _enemyMaxShield;
                return;
            }
        }

        public virtual void EnemyShieldReduction(int value)
        {
            if(_enemyShield > 0)
            {
                _enemyShield -= value;
            }
            else
            {
                _enemyShield = 0;
                return;
            }
        }

        #endregion


        #region  Enemy Attack
    
        public virtual void SetEnemyAttack(float enemyAttack,float enemyMaxAttack)
        {
            _enemyAttack = enemyAttack;
            _enemyMaxAttack = enemyMaxAttack;
        }

        private float attackTime = 0;
        public virtual void EnemyAttackFunction(float damageValue)
        {
            attackTime += Time.deltaTime * .5f;

            if (attackTime > 1)
            {
                if(_enemyBullets.Count > 0 )
                {
                    EnemyBullet enemyBullet = enemyBulletController.GetEnemyBulletFromPool(_enemyBullets);
                    Vector2 pos = transform.GetChild(0).transform.position;
                    enemyBullet.SetBulletDamage(damageValue);
                    enemyBullet.EnemyBulletMovement(collisionTarget.transform,transform.position);
                    StartCoroutine(enemyBulletController.DisableEnemyBulletAfterDelay(_enemyBullets,enemyBullet,transform.position,3));
                } 
               
                attackTime = 0;
            }
        }


        #endregion
        
    
        #region  Enemy Defense

        public virtual void SetEnemyDefense(int defense,int maxDefense)
        {
            _enemyDefense = defense;
            _enemyMaxDefense = maxDefense;
        }


        public virtual void EnemyDefenseFunction()
        {

        }


        #endregion   


        public virtual void SetEnemyPosition(Vector3 newPos)
        {
            transform.position = newPos;
        }

        public virtual void SetEnemySprite(Sprite enemySprite)
        {
            enemyImage.sprite = enemySprite;
        }

        

        public void EnemyPropertyAdjust(EnemyData enemyData,Transform target,int enemyNameNumber,Vector3 enemyPosition)
        {
            SetEnemyName(enemyData.EnemyName, enemyNameNumber);
            SetEnemySprite(enemyData.EnemySprite);
            SetEnemyHealt(enemyData.EnemyHealt, enemyData.EnemyMaxHealt);
            SetEnemySpeed(enemyData.EnemySpeed, enemyData.EnemyMaxSpeed);
            SetEnemyAttack(enemyData.EnemyAttack, enemyData.EnemyMaxAttack);
            SetEnemyShield(enemyData.EnemyShield, enemyData.EnemyMaxShield);
            SetEnemyDamage(enemyData.EnemyDamage, enemyData.EnemyMaxDamage);
            SetEnemyDefense(enemyData.EnemyDefense, enemyData.EnemyMaxDefense);
            SetTargetMovement(target);
            SetEnemyPosition(enemyPosition);
        }

        public virtual BaseEnemy EnemyClone()
        {
            BaseEnemy clonedEnemy = (BaseEnemy)MemberwiseClone();


            // Derin kopya: enemyBullets nesnesini yeniden oluştur ve içeriği kopyala
            BaseEnemy a = GameObject.Instantiate(clonedEnemy);
            SetEnemyChildGameObjectActive(a);
            a.isFire = false;
            return a;
        }

        private void SetEnemyChildGameObjectActive(BaseEnemy baseEnemy)
        {
            for (int i = 0; i < baseEnemy.transform.GetChild(0).childCount; i++)
            {
                baseEnemy.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
            }
        }

        public static void EnemyHealtReductionFindEnemyType(GameObject gameObject, float value)
        {
            BaseEnemy enemy = gameObject.GetComponent<BaseEnemy>();
            if(enemy)
            {
                enemy.EnemyHealtReduction(value);
                return;
            }
            return;
        }
        
        public virtual void EnemyDestroy()
        {
            enemyCoinFactory.EnemyCoinCreate(EnemyCoin.NameEnum.EnemyCoinNameEnum.EnemCoin_1,transform.position,botyGold);
            gameObject.SetActive(false);

        }



        public virtual void SetTargetMovement(Transform target)
        {
            this.target = target.gameObject;
            pos = target.position;
            StartCoroutine(Move());
        }

        private  IEnumerator Move()
        {
            while (transform.position != pos && !isStop)
            {
                if(!isPause)
                {
                    if(!isFire)
                    {
                        Movement(pos);
                    }
                    else
                    {
                        EnemyAttackFunction(_enemyDamage);
                    }

                }
                yield return null;
            }
        }

        public virtual void Movement(Vector3 target)
        {
            if(!isPause && !isStop)
            transform.position = Vector3.MoveTowards(transform.position,target, Time.deltaTime * 2);
        }


        [SerializeField] private GameObject collisionTarget;

        

        void OnCollisionStay2D(Collision2D collision)
        {
            TargetTowerTypeFind(collision.collider.gameObject,true);
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            TargetTowerTypeFind(collision.collider.gameObject,false);
        }



        private void TargetTowerTypeFind(GameObject targetTower,bool value)
        {
            if(targetTower.gameObject.CompareTag("MainTower"))
            {
                if( targetTower.gameObject.tag != "MainTower" && targetTower.gameObject.tag != "TowerBullet")
                {
                    GameObject a = targetTower;
                    collisionTarget = a;
                }
                collisionTarget = targetTower;
                    isFire =true;
            }
            else
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
                    case "MainTower":
                        isFire = value;
                        collisionTarget = targetTower;
                    break;
                    default:
                    break;
                }
            }
            
        }

        public virtual void EnemyMovementPause()
        {
            isPause = true;
            Time.timeScale = 0f;
        }

        public virtual void EnemyMovementResume()
        {
            isPause = false;
            Time.timeScale = 1f;
        }

        public virtual void EnemyMovementStop()
        {
            isPause = true;
            isStop = true;
            Time.timeScale = 0;
            
        }

        public virtual void EnemyMovementStart()
        {
            isPause = false;
            
            if(isStop) isStop = false;
            Time.timeScale = 1f;
            StartCoroutine(Move());
        
        }

      

        void OnEnable()
        {
            StopCoroutine(Move());
        }
    }
}
