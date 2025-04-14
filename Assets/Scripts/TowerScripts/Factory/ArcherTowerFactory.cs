using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class ArcherTowerFactory : IArcherTowerFactory
    {
        public Tower Create(TowerName towerName,Vector3 towerPosition,int index)
        {
           
            GameObject tower = null;
            GameObject prefab = null;

            prefab = Resources.Load<GameObject>($"Tower/ArcherTowerPrefabs/{towerName.ToString()}");
            if(prefab != null)
            {
                tower = GameObject.Instantiate(prefab);
                tower.name = tower.name.Replace("_1(Clone)",$"_ {index}");
            }
                        

            return tower.GetComponent<ArcherTower>();

        }
    }

}
