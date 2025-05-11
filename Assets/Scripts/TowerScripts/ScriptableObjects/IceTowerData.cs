using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerData.Ice
{
    [Serializable]
    public class IceTowerData 
    {
        public string iceTowerName;
        public Sprite iceTowerSprite;
        public float iceTowerhealt;
        public float iceTowerShield;
        public float iceTowerDamage;

        public int iceTowerLevel;

        public int iceTowerAttackSpeed;
        
        public int iceTowerRange;
        
        public int iceTowerCost;
    
    }

}
