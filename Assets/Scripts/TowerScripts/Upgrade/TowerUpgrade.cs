using System.Collections;
using System.Collections.Generic;
using TowerDatas.Archer;
using TowerDatas.Fire;
using TowerDatas.Ice;
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
                tower.SetTowerProperty(tower.transform.position,tower.TowerAttackType,archerTowerData);
                towerSpriteRenderer.sprite = archerTowerData.towerSprite;
            }
            else if(tower is FireTower)
            {
                if(tower.TowerLevel <towerDataScriptableObject.FireTowerDatas.Length)
                tower.TowerLevel++;
                FireTowerData fireTowerData = towerDataScriptableObject.FireTowerDatas[tower.TowerLevel-1];
                tower.SetTowerProperty(tower.transform.position,tower.TowerAttackType,fireTowerData);
                towerSpriteRenderer.sprite = fireTowerData.towerSprite;
            }
            else if(tower is IceTower)
            {
                if(tower.TowerLevel <towerDataScriptableObject.FireTowerDatas.Length)
                tower.TowerLevel++;
                IceTowerData iceTowerData = towerDataScriptableObject.IceTowerDatas[tower.TowerLevel-1];
                tower.SetTowerProperty(tower.transform.position,tower.TowerAttackType,iceTowerData);
                towerSpriteRenderer.sprite = iceTowerData.towerSprite;
            }

            GameManager.Instance.TowerObjectsUpgradeStateControl();
       
        }
        
    }

}
