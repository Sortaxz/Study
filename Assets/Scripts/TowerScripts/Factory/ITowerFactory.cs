
namespace Towers
{
    public interface IArcherTowerFactory
    {
        Tower Create(TowerName towerName);
    }
    
    public interface IFireTowerFactory
    {
        Tower Create(TowerName towerName);
    }
    public interface IIceTowerFactory
    {
        Tower Create(TowerName towerName);
    }
}
