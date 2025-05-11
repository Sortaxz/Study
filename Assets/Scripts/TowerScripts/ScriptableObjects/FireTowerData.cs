using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerData.Fire
{
    [Serializable]
    public class FireTowerData 
    {
        public string fireTowerName;
        public float fireTowerHealt;
        public float fireTowerShield;
        public float fireTowerDamage;

        public int fireTowerLevel;

        public int fireTowerAttackSpeed;
        
        public int fireTowerRange;
        
        public int fireTowerCost;
    }

}
