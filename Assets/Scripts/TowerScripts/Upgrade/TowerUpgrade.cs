using System.Collections;
using System.Collections.Generic;
using TowerData.Archer;
using TowerData.Fire;
using TowerData.Ice;
using Towers.DataScriptableObject;
using UnityEngine;

namespace Towers.UpgradeControl
{
    public class TowerUpgrade 
    {
        private TowerDateScriptableObject towerDataScriptableObject;
        public TowerUpgrade()
        {
            towerDataScriptableObject = Resources.Load<TowerDateScriptableObject>("ScriptableObjects/TowerDataScriptableObject");
        }
        public void Upgrade(Tower tower)
        {
            SpriteRenderer towerSpriteRenderer = tower.GetComponent<SpriteRenderer>();
            
            GameManager.Instance.CoinReduction(tower.TowerCost);
            

            if(tower is ArcherTower)
            {
                if(tower.TowerLevel <towerDataScriptableObject.ArcherTowerDatas.Length)
                tower.TowerLevel++;
                ArcherTowerData archerTowerData = towerDataScriptableObject.ArcherTowerDatas[tower.TowerLevel];
                tower.SetTowerProperty(tower.transform.position,tower.TowerAttackType,archerTowerData.archerTowerHealt,archerTowerData.archerTowerLevel,archerTowerData.archerTowerDamage,archerTowerData.towerAttackSpeed,archerTowerData.towerRange,archerTowerData.towerCost);
                towerSpriteRenderer.sprite = archerTowerData.archerTowerSprite;
            }
            else if(tower is FireTower)
            {
                if(tower.TowerLevel <towerDataScriptableObject.FireTowerDatas.Length)
                tower.TowerLevel++;
                FireTowerData fireTowerData = towerDataScriptableObject.FireTowerDatas[tower.TowerLevel-1];
                tower.SetTowerProperty(tower.transform.position,tower.TowerAttackType,fireTowerData.fireTowerHealt,fireTowerData.fireTowerLevel,fireTowerData.fireTowerDamage,fireTowerData.fireTowerAttackSpeed,fireTowerData.fireTowerRange,fireTowerData.fireTowerCost);
                towerSpriteRenderer.sprite = fireTowerData.fireTowerSprite;
            }
            else if(tower is IceTower)
            {
                if(tower.TowerLevel <towerDataScriptableObject.FireTowerDatas.Length)
                tower.TowerLevel++;
                IceTowerData iceTowerData = towerDataScriptableObject.IceTowerDatas[tower.TowerLevel-1];
                tower.SetTowerProperty(tower.transform.position,tower.TowerAttackType,iceTowerData.iceTowerhealt,iceTowerData.iceTowerLevel,iceTowerData.iceTowerDamage,iceTowerData.iceTowerAttackSpeed,iceTowerData.iceTowerRange,iceTowerData.iceTowerCost);
                towerSpriteRenderer.sprite = iceTowerData.iceTowerSprite;
            }

            GameManager.Instance.TowerObjectsUpgradeStateControl();
       
        }
        
    }

}
