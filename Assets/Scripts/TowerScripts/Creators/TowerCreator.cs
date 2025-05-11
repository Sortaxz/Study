
using System.Collections.Generic;
using System.Linq;
using Towers.DataScriptableObject;
using UnityEngine;

namespace Towers
{
    public class TowerCreator 
    {
        private int a = 0;
        private Dictionary<string,Tower> towers = new Dictionary<string,Tower>();
        private TowerDateScriptableObject towerDateScriptableObject;

        public TowerCreator()
        {
            towerDateScriptableObject = Resources.Load<TowerDateScriptableObject>("ScriptableObjects/TowerDataScriptableObject");
        }

        public Tower Create( ITowerFactor towerFactor,TowerName towerName,Vector2 towerPosition)
        {
            a++;
            Tower tower =  CreateTower(towerFactor, towerName,towerPosition,a);
            towers.Add(tower.name,tower);
            return tower;
        }

        private Tower CreateTower(ITowerFactor towerFactor,TowerName towerName,Vector2 towerPosition,int index)
        {
            switch (towerFactor)
            {
                case ArcherTowerFactory:
                    ArcherTowerFactory archerTowerFactory = (ArcherTowerFactory)towerFactor;
                    archerTowerFactory.SetTowerDateScriptableObject(towerDateScriptableObject);
                    return archerTowerFactory.Create(towerName,towerPosition,index);
                case FireTowerFactory:
                    FireTowerFactory fireTowerFactory = (FireTowerFactory)towerFactor;
                    fireTowerFactory.SetTowerDateScriptableObject(towerDateScriptableObject);
                    return fireTowerFactory.Create(towerName,towerPosition,index);
                case IceTowerFactory:
                    IceTowerFactory iceTowerFactory = (IceTowerFactory)towerFactor;
                    iceTowerFactory.SetTowerDateScriptableObject(towerDateScriptableObject);
                    return iceTowerFactory.Create(towerName,towerPosition,index);
                default:
                    return null;
            }
        }

        public Tower[] GetTowerList()
        {
            return towers.Values.ToArray();
        }

        internal void TowersFunctionPause()
        {
            foreach (var item in towers.Values)
            {
                item.TowerFunctionPause();
            }
        }

        internal void TowersFunctionResume()
        {
            foreach (var item in towers.Values)
            {
                item.TowerFunctionResume();
            }
        }

        internal void TowersFunctionStop()
        {
            foreach (var item in towers.Values)
            {
                item.TowerFunctionStop();
            }
        }

        internal void TowersFunctionPlay()
        {
            foreach (var item in towers.Values)
            {
                item.TowerFunctionStart();
            }
        }

        public void TowersReset()
        {
            TowersFunctionStop();
            foreach (var item in towers.Values)
            {
                if(item != null)
                {
                    GameObject.Destroy(item.gameObject);
                }
            }
            towers.Clear();
        }

        public Tower GetTowerObjectFromTowerList(string towerName)
        {
            if(towers.TryGetValue(towerName, out Tower tower))
            {
                return tower; 
            }
            return null;
        }

       

    }

}
