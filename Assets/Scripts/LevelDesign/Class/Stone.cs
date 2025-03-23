
using System;
using Rewards;
using UnityEngine;

namespace Forest
{
    
    public class Stone :MonoBehaviour
    {

        private string stoneName;
        public string StoneName => stoneName;

        private float stoneHealt;
        public float StoneHealt => stoneHealt; 
        
        private int stoneShield;
        public int StoneShield => stoneShield;



        public void StoneInitialize(string stoneName,float stoneHealt,int stoneShield)
        {
            this.stoneName = stoneName;
            this.stoneHealt = stoneHealt;
            this.stoneShield = stoneShield;
        }

        public void SetStoneHealt(float stoneHealt)
        {
            this.stoneHealt = stoneHealt;
        }

        public void SetStoneShield(int stoneShield)
        {
            this.stoneShield = stoneShield;
        }


        


    }

}

