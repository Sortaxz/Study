using System.Collections;
using System.Collections.Generic;
using Enemy;
using TowerBulletControl;
using TowerBulletEnums;
using UnityEngine;

namespace Towers
{
    public class IceTower : Tower
    {

        private GameObject target;


        void Awake()
        {
            towerUIController = GetComponent<TowerUIController>();
            towerBulletController = new TowerBulletController();
            towerBullets = towerBulletController.CreateTowerBullet(transform,Vector3.zero,TowerBulletTypeEnum.ArcherTowerBullet,TowerBulletNameEnum.ArcherTowerBullet_1,10);
            

        }

        void Start()
        {
            StandartFire(towerTargetPriority);
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
