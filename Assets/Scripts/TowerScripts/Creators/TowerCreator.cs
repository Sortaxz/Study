
using Unity.Mathematics;

namespace Towers
{
    public class TowerCreator 
    {
        public Tower Create( ITowerFactor towerFactor,TowerName towerName)
        {
            return CreateTower(towerFactor, towerName);
        }

        private Tower CreateTower(ITowerFactor towerFactor,TowerName towerName)
        {
            switch (towerFactor)
            {
                case ArcherTowerFactory:
                    ArcherTowerFactory archerTowerFactory = (ArcherTowerFactory)towerFactor;
                    return archerTowerFactory.Create(towerName);
                case FireTowerFactory:
                    FireTowerFactory fireTowerFactory = (FireTowerFactory)towerFactor;
                    return fireTowerFactory.Create(towerName);
                case IceTowerFactory:
                    IceTowerFactory iceTowerFactory = (IceTowerFactory)towerFactor;
                    return iceTowerFactory.Create(towerName);
                default:
                    return null;
            }
        }

    }

}
