using System.Collections;
using System.Collections.Generic;
using TowerDatas.Archer;
using Towers.DataScriptableObject;
using UnityEngine;

namespace Towers
{
    public class ArcherTowerFactory : IArcherTowerFactory
    {
        private TowerDateScriptableObject towerDateScriptableObject;

        public void SetTowerDateScriptableObject(TowerDateScriptableObject _towerDateScriptableObject)  
        {
            towerDateScriptableObject = _towerDateScriptableObject;
        }
        
        public Tower Create(TowerName towerName,Vector3 towerPosition,int index)
        {
           
            GameObject tower = null;
            GameObject prefab = null;

            prefab = Resources.Load<GameObject>($"Tower/ArcherTowerPrefabs/{towerName.ToString()}");
            if(prefab != null)
            {
                tower = GameObject.Instantiate(prefab);
                tower.name = tower.name.Replace("_1(Clone)",$"_ {index}");
                ArcherTower archerTower = tower.GetComponent<ArcherTower>();
                A(archerTower,tower.GetComponent<SpriteRenderer>().sprite,towerPosition);
            }

            return tower.GetComponent<ArcherTower>();

        }


        public void A(ArcherTower archerTower,Sprite sprite,Vector3 pos)
        {
            int index = 0;
            for (int i = 0; i < towerDateScriptableObject.ArcherTowerDatas.Length; i++)
            {
                if(towerDateScriptableObject.ArcherTowerDatas[i].towerName == sprite.name) 
                {
                    index = i;
                    break;
                }
            }
            ArcherTowerData archerTowerData = towerDateScriptableObject.ArcherTowerDatas[index];
            archerTower.SetTowerProperty(pos,TowerAttackType.Single,archerTowerData);

        }
    }

}
