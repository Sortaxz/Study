using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balance
{
    public class BalanceOperations 
    {
        private int coinValue;


        public int CoinValueIncrease(int increaseValue)
        {
            coinValue+=increaseValue;
            return coinValue;
        }

        public int CoinValueReduction(int reductionValue)
        {
            coinValue -= reductionValue;
            return coinValue;   
        }
    }

}
