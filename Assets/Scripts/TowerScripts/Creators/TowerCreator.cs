
using Unity.Mathematics;
using UnityEngine;

namespace Towers
{
    public class TowerCreator 
    {
        private int a = 0;
        public Tower Create( ITowerFactor towerFactor,TowerName towerName,Vector2 towerPosition)
        {
            a++;
            return CreateTower(towerFactor, towerName,towerPosition,a);
        }

        private Tower CreateTower(ITowerFactor towerFactor,TowerName towerName,Vector2 towerPosition,int index)
        {
            switch (towerFactor)
            {
                case ArcherTowerFactory:
                    ArcherTowerFactory archerTowerFactory = (ArcherTowerFactory)towerFactor;
                    return archerTowerFactory.Create(towerName,towerPosition,index);
                case FireTowerFactory:
                    FireTowerFactory fireTowerFactory = (FireTowerFactory)towerFactor;
                    return fireTowerFactory.Create(towerName,towerPosition,index);
                case IceTowerFactory:
                    IceTowerFactory iceTowerFactory = (IceTowerFactory)towerFactor;
                    return iceTowerFactory.Create(towerName,towerPosition,index);
                default:
                    return null;
            }
        }

    }

}
