using System.Collections;
using System.Collections.Generic;
using TowerBulletEnums;
using UnityEngine;

namespace TowerBulletControl
{
    public class TowerBulletController 
    {
        private Queue<TowerBullet> towerBullets;

        public void CreateTowerBullet(Transform bulletParent,Vector3 bulletPosition,TowerBulletTypeEnum towerBulletType,TowerBulletNameEnum towerBulletName,int bulletCount)
        {
            towerBullets = new Queue<TowerBullet>();

            for (int i = 0; i < bulletCount; i++)
            {
                GameObject prefab = Resources.Load<GameObject>(FindTowerBulletName(towerBulletType,towerBulletName));
                GameObject newTowerBullet = GameObject.Instantiate(prefab,bulletPosition,Quaternion.identity,bulletParent);
                newTowerBullet.SetActive(false);
                SetTowerBulletName(newTowerBullet,i+1);
                towerBullets.Enqueue(newTowerBullet.GetComponent<TowerBullet>());
            }

            
        }


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

        private void SetTowerBulletName(GameObject towerBullet,int index)
        {
            string towerBulletName = towerBullet.name.Replace("(Clone)","");
            towerBulletName += $"_{index}";
            towerBullet.name = towerBulletName;
        }

        public Queue<TowerBullet> GetTowerBulletsList()
        {
            return towerBullets;
        }

        public TowerBullet GetFromTowerBulletList(GameObject target)
        {
            if(towerBullets.Count > 0)
            {
                TowerBullet towerBullet = towerBullets.Dequeue();
                towerBullet.gameObject.SetActive(true);
                //towerBullet.TowerBulletMovement(GameManager.Instance.TowerBullet.transform.position);
                towerBullet.SetTowerBulletTarget(target,delegate{
                    ReturToTowerBulletList(towerBullet,Vector3.zero);
                });
                return towerBullet;
            }
            return null;
        }

        public void ReturToTowerBulletList(TowerBullet towerBullet,Vector3 position)
        {
            towerBullet.transform.position = position;
            towerBullet.gameObject.SetActive(false);
            towerBullets.Enqueue(towerBullet);
        }


    }

}
