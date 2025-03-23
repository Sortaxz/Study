using ForestEnums;
using UnityEngine;

namespace Forest
{
    public class Tree : MonoBehaviour
    {
        private string treeName;
        public string TreeName => treeName;

        private float treeHealt;
        public float TreeHealt => treeHealt; 
        
        private int treeShield;
        public int TreeShield => treeShield;


        public void TreeInitialize(string treeName,float treeHealt,int treeShield)
        {
            this.treeName = treeName;
            this.treeHealt = treeHealt;
            this.treeShield = treeShield;
        }

        public void SetStoneHealt(float _treeHealt)
        {
            treeHealt = _treeHealt;
        }

        public void SetStoneShield(int _treeShield)
        {
            treeShield = _treeShield;
        }

        public void GetStoneItemReward()
        {
            
        }
        
        public void GetEssenceItemReward()
        {

        }
        
    }

}

