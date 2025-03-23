using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public abstract class Tower : MonoBehaviour
    {
        private TowerAttackType towerAttackType; 
        public TowerAttackType TowerAttackType { get { return towerAttackType;} set { towerAttackType = value;}}
        
        private int towerDamage;
        public int TowerDamage { get { return towerDamage;} set { towerDamage = value;} }
        
        private int towerAttackSpeed;
        public int TowerAttackSpeed { get { return towerAttackSpeed;} set { towerAttackSpeed = value;}}
        
        private int towerRange;
        public int TowerRange { get { return towerRange;} set { towerRange = value;}}
        
        private GameObject towerTargetPriority;
        public GameObject TowerTargetPriority { get { return towerTargetPriority;} set { towerTargetPriority = value;}}
        
        private int towerCost;
        public int TowerCost { get { return towerCost;} set { towerCost = value;} }
    
        public abstract void SetTowerAttackType(TowerAttackType towerAttackType);
        public abstract void SetTowerDamage(int damage);
        public abstract void SetTowerAttackSpeed(int attackSpeed);
        public abstract void SetTowerRange(int range);
        public abstract void SetTowerTargetPriority(GameObject targetPriority);
        public abstract void SetTowerCost(int cost);
    }

}
