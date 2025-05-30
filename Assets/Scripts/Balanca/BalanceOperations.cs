using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balance
{
    public class BalanceOperations 
    {
        private float coinValue;
        public float CoinValue => coinValue;

        public float CoinValueIncrease(int increaseValue)
        {
            coinValue+=increaseValue;
            return coinValue;
        }

        public float CoinValueReduction(float reductionValue)
        {
            float result = coinValue - reductionValue; 
            
            if(result > 0)
            {
                coinValue -= reductionValue;
            }
            else
            {
                coinValue = 0;
            }

            return coinValue;   
        }

        public float GetCoinValue()
        {
            return coinValue;
        }
    }

}
