using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class ArcherTower : Tower,IArcherTower
    {
        void Awake()
        {
            towerBullets = new Queue<TowerBullet>();
            towerHealt = 100;
            towerBulletPrefab = Resources.Load<TowerBullet>("Tower/Bullets/TowerBullet");
            for (int i = 0; i < 10; i++)
            {
                TowerBullet newTowerBullet = Instantiate(towerBulletPrefab);
                newTowerBullet.gameObject.SetActive(false);
                newTowerBullet.SetTowerBulletName("TowerBullet",i);
                towerBullets.Enqueue(newTowerBullet);
            }
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                foreach (var item in towerBullets)
                {
                    print(item);
                }
            }
        }

        public override void SetTowerAttackSpeed(int attackSpeed)
        {
            TowerAttackSpeed = attackSpeed;
        }

        public override void SetTowerAttackType(TowerAttackType towerAttackType)
        {
            TowerAttackType = towerAttackType;
        }

        public override void SetTowerCost(int cost)
        {
            TowerCost = cost;
        }

        public override void SetTowerDamage(int damage)
        {
            TowerDamage = damage;
        }

        public override void SetTowerRange(int range)
        {
            TowerRange = range;
        }

        public override void SetTowerTargetPriority(GameObject targetPriority)
        {
            TowerTargetPriority = targetPriority;
        }

       

        void OnTriggerEnter2D(Collider2D collision)
        {
            print(collision.gameObject.name);
        }
    }

}
