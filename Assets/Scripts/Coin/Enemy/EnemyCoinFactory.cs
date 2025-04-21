using System.Collections;
using System.Collections.Generic;
using EnemyCoin.NameEnum;
using UnityEngine;

namespace EnemyCoin.EnemyFactory
{
    public class EnemyCoinFactory 
    {
        public EnemyCoin EnemyCoinCreate(EnemyCoinNameEnum enemyCoinName)
        {
            GameObject prefab = Resources.Load<GameObject>($"EnemyPrefabs/EnemyCoinPrefabs/{enemyCoinName}");
            return GameObject.Instantiate(prefab).GetComponent<EnemyCoin>();
        }
    }

}
