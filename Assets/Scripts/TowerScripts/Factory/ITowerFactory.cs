
using UnityEngine;

namespace Towers
{
    public interface ITowerFactor{}
    public interface IArcherTowerFactory : ITowerFactor
    {
        Tower Create(TowerName towerName,Vector3 towerPosition);
    }
    
    public interface IFireTowerFactory : ITowerFactor
    {
        Tower Create(TowerName towerName,Vector3 towerPosition);
    }
    public interface IIceTowerFactory : ITowerFactor
    {
        Tower Create(TowerName towerName,Vector3 towerPosition);
    }
}
