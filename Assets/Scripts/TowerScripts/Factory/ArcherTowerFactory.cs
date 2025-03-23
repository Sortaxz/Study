using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class ArcherTowerFactory : IArcherTowerFactory
    {
        public Tower Create(TowerName towerName)
        {
            
           
            GameObject tower = null;
            GameObject prefab = null;

            prefab = Resources.Load<GameObject>($"Tower/{towerName.ToString()}");
            if(prefab != null)
            {
                tower = GameObject.Instantiate(prefab);
            }
                        

            return tower.GetComponent<ArcherTower>();

        }
    }

}
