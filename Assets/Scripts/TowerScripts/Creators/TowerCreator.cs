
using Unity.Mathematics;
using UnityEngine;

namespace Towers
{
    public class TowerCreator 
    {
        public Tower Create( ITowerFactor towerFactor,TowerName towerName,Vector2 towerPosition)
        {
            return CreateTower(towerFactor, towerName,towerPosition);
        }

        private Tower CreateTower(ITowerFactor towerFactor,TowerName towerName,Vector2 towerPosition)
        {
            switch (towerFactor)
            {
                case ArcherTowerFactory:
                    ArcherTowerFactory archerTowerFactory = (ArcherTowerFactory)towerFactor;
                    return archerTowerFactory.Create(towerName,towerPosition);
                case FireTowerFactory:
                    FireTowerFactory fireTowerFactory = (FireTowerFactory)towerFactor;
                    return fireTowerFactory.Create(towerName,towerPosition);
                case IceTowerFactory:
                    IceTowerFactory iceTowerFactory = (IceTowerFactory)towerFactor;
                    return iceTowerFactory.Create(towerName,towerPosition);
                default:
                    return null;
            }
        }

    }

}
