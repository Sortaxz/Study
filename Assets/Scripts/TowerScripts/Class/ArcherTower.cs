using System.Collections;
using System.Collections.Generic;
using ArcherTowerFireInterfes;
using Enemy;
using TowerBulletControl;
using TowerBulletEnums;
using UnityEngine;

namespace Towers
{
    public class ArcherTower : Tower
    {

        private GameObject target;


        void Awake()
        {
            towerBulletController = new TowerBulletController();
            towerBulletController.CreateTowerBullet(transform,Vector3.zero,TowerBulletTypeEnum.ArcherTowerBullet,TowerBulletNameEnum.ArcherTowerBullet_1,10);
        }

        void Update()
        {
           
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

        public override void SetTowerTargetPriority(GameObject _targetPriority)
        {
            if(towerTargetPriority !=  _targetPriority  && _targetPriority.GetComponent<BaseEnemy>() != null)
            {
                towerTargetPriority = _targetPriority;

            }
        }

        
        
    }

}
