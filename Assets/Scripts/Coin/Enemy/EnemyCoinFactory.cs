using System.Collections;
using System.Collections.Generic;
using EnemyCoin.NameEnum;
using UnityEngine;

namespace EnemyCoin.Factory
{
    public class EnemyCoinFactory 
    {
        //Enemy kurşunu oluşturmamizi sağliyan method
        public EnemyCoin EnemyCoinCreate(EnemyCoinNameEnum enemyCoinName,int enemyCoinAmount)
        {
            GameObject prefab = Resources.Load<GameObject>($"EnemyPrefabs/EnemyCoinPrefabs/{enemyCoinName}");
            
            EnemyCoin enemyCoin = GameObject.Instantiate(prefab).GetComponent<EnemyCoin>();
            enemyCoin.SetAmount(enemyCoinAmount);

            return enemyCoin;
        }
    }

}
