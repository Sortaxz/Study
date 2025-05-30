using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDatas
{
    [Serializable]
    public class TowerData
    {
        public string towerName;
        public Sprite towerSprite;
        public float towerHealt;
        public float towerMaxHealt;
        public float towerShield;
        public float towerMaxShield;
        public float towerDamage;
        public float towerMaxDamage;

        public int towerLevel;

        public float towerAttackSpeed;
        public float towerMaxAttackSpeed;

        public float towerRange;

        public float towerCost;
    }

}
