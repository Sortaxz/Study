using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class FireTowerFactory : IFireTowerFactory
    {
        public Tower Create(TowerName towerName)
        {
            GameObject prefab = Resources.Load<GameObject>($"Tower/FireTowerPrefabs/{towerName}");
            GameObject fireTower = null;
            if(prefab !=null)
            {
                fireTower = GameObject.Instantiate(prefab);
                fireTower.name = fireTower.name.Replace("(Clone)","");
            }
            
            return fireTower.GetComponent<Tower>();
        }
    }

}
