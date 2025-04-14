using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class IceTower : Tower
    {

        void Awake()
        {
            towerHealt = 100;
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
