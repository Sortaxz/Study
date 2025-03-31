
using UnityEngine;

using Enemy;
using System;
using System.Collections.Generic;

namespace EnemyFactorys
{
    [Serializable]
    public class EnemyFactory
    {
        private  Dictionary<string, BaseEnemy> enemyPool = new Dictionary<string, BaseEnemy>();

        public BaseEnemy Create(EnemyNameEnum enemyName, Vector3 position)
        {
            if(enemyPool.TryGetValue(enemyName.ToString(), out BaseEnemy enemy))
            {
                BaseEnemy baseEnemy =  enemy.EnemyClone();
                
                 baseEnemy.SetEnemyPosition(position);
                baseEnemy.SetEnemyName(baseEnemy.name);
                return  baseEnemy;
            }

            GameObject prefab = Resources.Load<GameObject>($"EnemyPrefabs/{enemyName.ToString()}");

            BaseEnemy _enemy = GameObject.Instantiate(prefab).GetComponent<BaseEnemy>();
            _enemy.SetEnemyPosition(position);
            _enemy.SetEnemyName(_enemy.name);

            enemyPool.Add(enemyName.ToString(),_enemy);

            return _enemy;

        }


        internal void SaveEnemyTypeFindToList(BaseEnemy enemy)
        {
            switch(enemy.tag)
            {
             
                case "MageEnemy":
             
                break;
             
                case "MeleeEnemy":
             
                break;
             
                case "RangeEnemy":
             
                break;
             
                case "TankEnemy":
             
                break;

                case "BossEnemy":
                break;
            
            }
        }

       
        int randomEnemyPositionIndex = 0;

        private void AdjustingEnemyPosition(BaseEnemy enemy,Transform[] enemyPositions,int randomIndex)
        {
            randomEnemyPositionIndex = randomIndex;
            enemy.SetEnemyPosition(enemyPositions[randomEnemyPositionIndex].position);
        }   


    }

}
