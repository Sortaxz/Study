using Enemy.Bullet;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Enemy
{
    public abstract class BaseEnemy :MonoBehaviour
    {
        protected GameObject target;
        protected Vector3 newPos;

        [SerializeField] protected string _enemyName;
        public string EnemyName => _enemyName;

        [SerializeField] protected float _enemyHealt;
        public float EnemyHealt => _enemyHealt;
        
        protected float _enemyMaxHealt;
        public float MaxEnemyMaxHealt => _enemyMaxHealt;

        [SerializeField] protected float _enemySpeed;
        public float EnemySpeed => _enemySpeed;

        protected float _enemyMaxSpeed;
        public float MaxEnemyMaxSpeed => _enemyMaxSpeed;


        [SerializeField] protected int _enemyShield;
        public int EnemyShield => _enemyShield;

        protected int _enemyMaxShield;
        public int MaxEnemyMaxShield => _enemyMaxShield;


        [SerializeField] protected int _enemyDamage;
        public int EnemyDamage => _enemyDamage;

        protected int _enemyMaxDamage;
        public int MaxEnemyMaxDamage => _enemyMaxDamage;


        [SerializeField] protected int _enemyAttack;
        public int EnemyAttack {get {return _enemyAttack;} set {_enemyAttack = value;} }

        protected float _enemyMaxAttack;
        public float MaxEnemyMaxAttack => _enemyMaxAttack;
        
        [SerializeField] protected int _enemyDefense;
        public int EnemyDefense => _enemyDefense;

        private int _enemyMaxDefense;
        public int EnemyMaxDefense => _enemyMaxDefense;            

        [SerializeField] protected bool isFire;
        public bool IsFire => isFire;

        public void SetEnemyName(string name)
        {
            transform.name = name.Replace("(Clone)","");
            _enemyName = transform.name;
        }

        #region  Enemy Healt
    
        public virtual void SetEnemyHealt(float healt,float maxHealt)
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
                return;
            }
        }

        public virtual void EnemyHealtReduction(float value)
        {
            if(_enemyHealt > 0)
            {
                _enemyHealt -= value;
            }
            else
            {
                _enemyHealt = 0;
                return;
            }
        }

        #endregion



        #region  Enemy Speed
    
        public virtual void SetEnemySpeed(int speed,int maxSpeed)
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
    
        public virtual void SetEnemyAttack(GameObject target,int enemyAttack,int enemyMaxAttack)
        {
            this.target = target;
            _enemyAttack = enemyAttack;
            _enemyMaxAttack = enemyMaxAttack;
        }

        public virtual void EnemyAttackFunction(int damageValue)
        {
            print("attak yapiyor");
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
    }

}
