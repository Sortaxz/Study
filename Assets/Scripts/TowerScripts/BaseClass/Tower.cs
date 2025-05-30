using System.Collections;
using System.Collections.Generic;
using Enemy;
using TowerBulletControl;
using TowerDatas;
using Towers.UpgradeControl;
using UnityEngine;

namespace Towers
{
    public abstract class Tower : MonoBehaviour
    {
        [SerializeField] protected GameObject towerTargetPriority;
        public GameObject TowerTargetPriority { get { return towerTargetPriority;} set { towerTargetPriority = value;}}
        
        [SerializeField] protected TowerUIController towerUIController;
        public TowerUIController TowerUIController => towerUIController;

        [SerializeField] protected List<TowerBullet> towerBullet;
        protected TowerBulletController towerBulletController;
        
        protected TowerAttackType towerAttackType; 
        public TowerAttackType TowerAttackType { get { return towerAttackType;} set { towerAttackType = value;}}
        
        [SerializeField] protected TowerBullet towerBulletPrefab;
        public TowerBullet TowerBulletPrefab => towerBulletPrefab;

        [SerializeField] protected Transform towerBulletsParent;
        public Transform TowerBulletsParent => towerBulletsParent;

        [SerializeField] protected Queue<BaseTowerBullet> towerBullets;
        public Queue<BaseTowerBullet> TowerBullets => towerBullets;

        protected TowerUpgrade towerUpgrade;
        public TowerUpgrade TowerUpgrade => towerUpgrade;

        [SerializeField]protected string towerName;
        public string TowerName => towerName;

        [SerializeField] protected float towerHealt;
        public float TowerHealt => towerHealt;

        [SerializeField]protected float maxTowerHealt;
        public float MaxTowerHealt => maxTowerHealt;
        
        [SerializeField]protected int towerLevel;
        public int TowerLevel {get { return towerLevel;} set { towerLevel = value;}}

        [SerializeField]protected float towerShield;
        public float TowerShield {get { return towerShield; } set { towerShield = value; } }


        [SerializeField]protected float towerDamage;
        public float TowerDamage { get { return towerDamage;} set { towerDamage = value;} }
        
        [SerializeField]protected float towerAttackSpeed;
        public float TowerAttackSpeed { get { return towerAttackSpeed;} set { towerAttackSpeed = value;}}
        
        [SerializeField]protected float towerRange;
        public float TowerRange { get { return towerRange;} set { towerRange = value;}}
        
        [SerializeField]protected float towerCost;
        public float TowerCost { get { return towerCost;} set { towerCost = value;} }


        [SerializeField] protected bool isStop = false;
        
        [SerializeField] protected bool isPause = false;



        public virtual void SetTowerName(string name)
        {
            if(transform.name.Contains("(Clone)"))
            {
                transform.name = name.Replace("(Clone)", "");
                return;
            }
            transform.name = name;
        }

        public virtual void SetTowerHealt(float _towerHealt,float _towerMaxHealt)
        {
            towerHealt = _towerHealt;
            maxTowerHealt = _towerMaxHealt;
            towerUIController.SetHealtBarValue(towerHealt);
        }

        #region  Kule'nin canini ayarlayabileceğin methodlar ve propert'ler

        public virtual void IncreaseTowerHealt(float value)
        {
            if (towerHealt < maxTowerHealt)
            {
                towerHealt += value;
            }
            else
            {
                towerHealt = maxTowerHealt;
            }
            towerUIController.HealtBarValueIncrease(towerHealt);
        }

        public virtual void ReductionTowerHealt(float value)
        {
            if (towerHealt > 0)
            {
                towerHealt -= value;
            }
            else if (towerHealt <= 0)
            {
                towerHealt = 0;
                Destroy(gameObject);
            }
            towerUIController.HealtBarValueIncrease(towerHealt);
        }

        #endregion


        public virtual void SetTowerPosition(Vector3 newPos)
        {
            transform.position = newPos;
        }

        public virtual void SetTowerLevel(int _towerLevel)
        {
            towerLevel = _towerLevel;
        }

        public virtual void SetTowerAttackType(TowerAttackType _towerAttackType)
        {
            towerAttackType = _towerAttackType;
        }

        public virtual void SetTowerDamage(float _damage)
        {
            towerDamage = _damage;
        }
        
        public virtual void SetTowerAttackSpeed(float _attackSpeed)
        {
            towerAttackSpeed = _attackSpeed;
        }
        
        public virtual void SetTowerRange(float _range)
        {
            towerRange = _range;
        }

        public virtual void SetTowerCost(float _cost)
        {
            towerCost = _cost;
        }

        public virtual void SetTowerShield(float _towerShield)
        {
            towerShield = _towerShield;
        }

        public virtual void SetTowerTargetPriority(GameObject targetPriority)
        {
            if (towerTargetPriority != targetPriority && targetPriority.GetComponent<BaseEnemy>() != null)
            {
                towerTargetPriority = targetPriority;

            }
        }

        public virtual void SetTowerProperty(Vector3 pos, TowerAttackType towerAttackType, TowerData towerData)
        {
            SetTowerHealt(towerData.towerHealt, towerData.towerMaxHealt);
            SetTowerPosition(pos);
            SetTowerAttackType(towerAttackType);
            SetTowerDamage(towerData.towerDamage);
            SetTowerAttackSpeed(towerData.towerAttackSpeed);
            SetTowerRange(towerData.towerRange);
            SetTowerCost(towerData.towerCost);
            SetTowerLevel(towerData.towerLevel);
            SetTowerShield(towerData.towerShield);
        }
        
        void OnTriggerEnter2D(Collider2D collision)
        {
            if(ControlCollisionGameobjectTag(collision.gameObject))
            {
                SetTowerTargetPriority(collision.gameObject);
            }
        }


        void OnTriggerStay2D(Collider2D collision)
        {
            if(towerTargetPriority == null)
            {
                if(ControlCollisionGameobjectTag(collision.gameObject))
                {
                    SetTowerTargetPriority(collision.gameObject);
                }
            }
            
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if(towerTargetPriority != null)
            towerTargetPriority = null;
        }

        public bool ControlCollisionGameobjectTag(GameObject collision)
        {
            if(collision.CompareTag("BossEnemy"))
            {
                return true;
            }
            else if(collision.CompareTag("MageEnemy"))
            {
                return true;
            }
            else if(collision.CompareTag("MeleeEnemy"))
            {
                return true;
            }
            else if(collision.CompareTag("RangeEnemy"))
            {
                return true;
            }
            else if(collision.CompareTag("TankEnemy"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        
        internal virtual void StandartFire(GameObject collision)
        {
            StartCoroutine(ArcherTowerStandartFire());
        }

        internal virtual IEnumerator ArcherTowerStandartFire()
        {

            BaseTowerBullet towerBullet = null;
            while (!isStop)
            {
                if (!isPause)
                {
                    if (towerTargetPriority != null)
                    {
                        towerBullet = towerBulletController.GetFromTowerBulletList(towerBullets, towerTargetPriority.gameObject, towerDamage);

                    }
                    bool value = towerTargetPriority == null ? false : true;
                    towerUIController.TowerFireIconOpen(value);
                    
                }
                

                yield return new WaitForSeconds(3);
                if (towerBullet != null)
                    towerBulletController.ReturToTowerBulletList(towerBullets, towerBullet, transform.position);
            }
        }

        public void TowerFunctionPause()
        {
            isPause = true;
        }

        public void TowerFunctionResume()
        {
            isPause = false;
        }

        public void TowerFunctionStop()
        {
            isStop = true;
        }

        public void TowerFunctionStart()
        {
            isStop = false;
            isPause = false;
        }

       
    }

}
