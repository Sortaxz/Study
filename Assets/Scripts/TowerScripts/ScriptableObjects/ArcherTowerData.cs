using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerData.Archer
{
    [Serializable]
    public class ArcherTowerData 
    {
        public string archerTowerName;
        public Sprite archerTowerSprite;
        public float archerTowerHealt;
        public float archerTowerShield;
        public float archerTowerDamage;

        public int archerTowerLevel;

        public int towerAttackSpeed;
        
        public int towerRange;
        
        public int towerCost;
    }

}
