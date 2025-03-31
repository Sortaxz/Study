using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class IceTowerFactory : IIceTowerFactory
    {
        public Tower Create(TowerName towerName)
        {
            GameObject prefab = Resources.Load<GameObject>($"Tower/IceTowerPrefabs/{towerName}");
            GameObject iceTower = null;
            if(prefab != null)
            {
                iceTower = GameObject.Instantiate(prefab);
                iceTower.name = iceTower.name.Replace("(Clone)","");
            }

            return iceTower.GetComponent<Tower>();
        }
    }


}
