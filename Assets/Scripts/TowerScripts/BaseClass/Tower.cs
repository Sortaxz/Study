using System.Collections;
using System.Collections.Generic;
using TowerBulletControl;
using UnityEngine;

namespace Towers
{
    public abstract class Tower : MonoBehaviour
    {
        [SerializeField] protected GameObject towerTargetPriority;
        public GameObject TowerTargetPriority { get { return towerTargetPriority;} set { towerTargetPriority = value;}}
        
        [SerializeField] protected List<TowerBullet> towerBullet;
        protected TowerBulletController towerBulletController;
        
        protected TowerAttackType towerAttackType; 
        public TowerAttackType TowerAttackType { get { return towerAttackType;} set { towerAttackType = value;}}
        
        [SerializeField] protected TowerBullet towerBulletPrefab;
        public TowerBullet TowerBulletPrefab => towerBulletPrefab;

        [SerializeField] protected Transform towerBulletsParent;
        public Transform TowerBulletsParent => towerBulletsParent;

        [SerializeField] protected Queue<TowerBullet> towerBullets;
        public Queue<TowerBullet> TowerBullets => towerBullets;

        protected string towerName;
        public string TowerName => towerName;

        [SerializeField] protected float towerHealt;
        public float TowerHealt => towerHealt;

        protected float maxTowerHealt;
        public float MaxTowerHealt => maxTowerHealt;

        
        protected int towerDamage;
        public int TowerDamage { get { return towerDamage;} set { towerDamage = value;} }
        
        protected int towerAttackSpeed;
        public int TowerAttackSpeed { get { return towerAttackSpeed;} set { towerAttackSpeed = value;}}
        
        protected int towerRange;
        public int TowerRange { get { return towerRange;} set { towerRange = value;}}
        
        protected int towerCost;
        public int TowerCost { get { return towerCost;} set { towerCost = value;} }

        public virtual void SetTowerName(string name)
        {
            if(transform.name.Contains("(Clone)"))
            {
                transform.name = name.Replace("(Clone)", "");
                return;
            }
            transform.name = name;
        }

        public virtual void IncreaseTowerHealt(float value)
        {
            if(towerHealt < maxTowerHealt)
            {
                towerHealt += value;
            }
            else
            {
                towerHealt = maxTowerHealt;
            }
        }

        public virtual void ReductionTowerHealt(float value)
        {
            if(towerHealt > 0)
            {
                towerHealt -= value;
            }
            else if(towerHealt <= 0)
            {
                towerHealt = 0;
                Destroy(gameObject);
            }
        }

        public virtual void SetTowerPosition(Vector3 newPos)
        {
            transform.position = newPos;
        }

        public abstract void SetTowerAttackType(TowerAttackType towerAttackType);
        public abstract void SetTowerDamage(int damage);
        public abstract void SetTowerAttackSpeed(int attackSpeed);
        public abstract void SetTowerRange(int range);
        public abstract void SetTowerTargetPriority(GameObject targetPriority);
        public abstract void SetTowerCost(int cost);

        
        void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.name != transform.name && collision.gameObject.tag != "TowerBullet")
            SetTowerTargetPriority(collision.gameObject);
            
            StandartFire(collision.gameObject);
        }


        void OnTriggerStay2D(Collider2D collision)
        {
            if(towerTargetPriority == null)
            {
                if(collision.gameObject.name != transform.name && collision.gameObject.tag != "TowerBullet")
                SetTowerTargetPriority(collision.gameObject);
            }

        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.gameObject.name != transform.name && collision.gameObject.tag != "TowerBullet")
            {
                towerTargetPriority = null;
            }
        }

        
        internal virtual void StandartFire(GameObject collision)
        {
            if(collision.gameObject.name != transform.name && collision.gameObject.tag != "TowerBullet")
                StartCoroutine(ArcherTowerStandartFire(collision));
        }

        internal virtual IEnumerator ArcherTowerStandartFire(GameObject collision)
        {
            while(towerTargetPriority != null)
            {
                if(towerTargetPriority != null)
                {
                    if(collision.gameObject.name != transform.name && collision.gameObject.tag != "TowerBullet")
                    towerBullet.Add(towerBulletController.GetFromTowerBulletList(collision.gameObject));

                }
                else
                {
                    StopCoroutine(ArcherTowerStandartFire(collision));
                }
                yield return new WaitForSeconds(3);  
            }
        }

    }

}
