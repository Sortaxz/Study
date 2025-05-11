using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balance
{
    public class BalanceOperations 
    {
        private int coinValue;
        public int CoinValue => coinValue;

        public int CoinValueIncrease(int increaseValue)
        {
            coinValue+=increaseValue;
            return coinValue;
        }

        public int CoinValueReduction(int reductionValue)
        {
            int result = coinValue - reductionValue; 
            
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

        public int GetCoinValue()
        {
            return coinValue;
        }
    }

}
