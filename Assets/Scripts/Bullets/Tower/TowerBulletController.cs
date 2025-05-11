using System.Collections;
using System.Collections.Generic;
using TowerBulletEnums;
using TowerBullets.ArcherTowerBullets;
using TowerBullets.FireTowerBullets;
using TowerBullets.IceTowerBullets;
using UnityEngine;

namespace TowerBulletControl
{
    public class TowerBulletController
    {
        

        public Queue<BaseTowerBullet> CreateTowerBullet(Transform bulletParent,Vector3 bulletPosition,TowerBulletTypeEnum towerBulletType,TowerBulletNameEnum towerBulletName,int bulletCount)
        {
            Queue<BaseTowerBullet> towerBullets = new Queue<BaseTowerBullet>();
            for (int i = 0; i < bulletCount; i++)
            {
                BaseTowerBullet prefab = Resources.Load<TowerBullet>(FindTowerBulletName(towerBulletType,towerBulletName));
                TowerBullet newTowerBullet = (TowerBullet)GameObject.Instantiate(prefab,bulletPosition,Quaternion.identity,bulletParent);
                newTowerBullet.SetTowerBulletName(newTowerBullet.gameObject.name,i);
                newTowerBullet.gameObject.SetActive(false);
                towerBullets.Enqueue(newTowerBullet);
            }
            
            return towerBullets;
        }
        

        //Verilen kurşun adina sahip olan kurşunu bulmamizi sağliyor.
        private string FindTowerBulletName(TowerBulletTypeEnum towerBulletType,TowerBulletNameEnum towerBulletName)
        {
            string path = "";
            switch (towerBulletType)
            {
                
                case TowerBulletTypeEnum.ArcherTowerBullet :
                    path = $"Tower/Bullets/ArcherTowerBulletPrefabs/{towerBulletName.ToString()}";
                break;
                
                case TowerBulletTypeEnum.FireTowerBullet:
                    path = $"Tower/Bullets/FireTowerBulletPrefabs/{towerBulletName.ToString()}";
                
                break;
                
                case TowerBulletTypeEnum.IceTowerBullet:
                    path = $"Tower/Bullets/IceTowerBulletPrefabs/{towerBulletName.ToString()}";
                break;
                
                default:
                    path = "";
                break;

            }
            return path;
        }

        public void FindTowerBulletType(BaseTowerBullet baseTowerBullet,Queue<BaseTowerBullet> towerBullets,int index)
        {
            if(baseTowerBullet is ArcherTowerBullet)
            {
                ArcherTowerBullet archerTowerBullet = (ArcherTowerBullet)baseTowerBullet;
                archerTowerBullet.SetTowerBulletName(archerTowerBullet.gameObject.name,index);
                archerTowerBullet.gameObject.SetActive(false);
                towerBullets.Enqueue(archerTowerBullet);
            }
            else if(baseTowerBullet is FireTowerBullet)
            {
                FireTowerBullet fireTowerBullet = (FireTowerBullet)baseTowerBullet;
                fireTowerBullet.SetTowerBulletName(fireTowerBullet.gameObject.name,index);
                fireTowerBullet.gameObject.SetActive(false);
                towerBullets.Enqueue(fireTowerBullet);
            }
            else if(baseTowerBullet is IceTowerBullet)
            {
                IceTowerBullet iceTowerBullet = (IceTowerBullet)baseTowerBullet;
                iceTowerBullet.SetTowerBulletName(iceTowerBullet.gameObject.name,index);
                iceTowerBullet.gameObject.SetActive(false);
                towerBullets.Enqueue(iceTowerBullet);
            }

        }

        public BaseTowerBullet GetFromTowerBulletList(Queue<BaseTowerBullet> _towerBullets,GameObject target,float towerDamage)
        {
            BaseTowerBullet towerBullet = _towerBullets.Dequeue();
            towerBullet.SetTowerBulletTarget(target,towerDamage);
            return towerBullet;
        }

        public void ReturToTowerBulletList(Queue<BaseTowerBullet> _towerBullets,BaseTowerBullet towerBullet,Vector3 pos)
        {
            towerBullet.transform.position = pos;
            towerBullet.RemoveTowerBulletTarget();
            _towerBullets.Enqueue(towerBullet);
        }

       

    }

}
