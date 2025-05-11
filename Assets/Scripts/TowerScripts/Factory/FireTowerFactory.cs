using System.Collections;
using System.Collections.Generic;
using TowerData.Fire;
using Towers.DataScriptableObject;
using UnityEngine;

namespace Towers
{
    public class FireTowerFactory : IFireTowerFactory
    {
        private TowerDateScriptableObject towerDateScriptableObject;

        public void SetTowerDateScriptableObject(TowerDateScriptableObject _towerDateScriptableObject)  
        {
            towerDateScriptableObject = _towerDateScriptableObject;
        }

        
        public Tower Create(TowerName towerName,Vector3 towerPosition,int index)
        {
            GameObject prefab = Resources.Load<GameObject>($"Tower/FireTowerPrefabs/{towerName}");
            GameObject fireTowerGameObject = null;
            if(prefab !=null)
            {
                fireTowerGameObject = GameObject.Instantiate(prefab);
                fireTowerGameObject.name = fireTowerGameObject.name.Replace("_1(Clone)",$"_ {index}");
                FireTower fireTower = fireTowerGameObject.GetComponent<FireTower>();
                A(fireTower,fireTower.GetComponent<SpriteRenderer>().sprite,towerPosition);
            }
            
            return fireTowerGameObject.GetComponent<Tower>();
        }

        public void A(FireTower fireTower,Sprite sprite,Vector3 pos)
        {
            int index = 0;
            for (int i = 0; i < towerDateScriptableObject.ArcherTower.Length; i++)
            {
                if(towerDateScriptableObject.ArcherTower[i].archerTowerName == sprite.name) 
                {
                    index = i;
                    break;
                }
            }
            FireTowerData fireTowerData = towerDateScriptableObject.FireTower[index];
            fireTower.SetTowerProperty(pos,TowerAttackType.Single,fireTowerData.fireTowerHealt,fireTowerData.fireTowerLevel,fireTowerData.fireTowerDamage,fireTowerData.fireTowerAttackSpeed,fireTowerData.fireTowerRange,fireTowerData.fireTowerCost);

        }
    }

}
