
using UnityEngine;

using Enemy;
using System;

namespace EnemyFactorys
{
    [Serializable]
    public class EnemyFactory  
    {
        public BaseEnemy Create(EnemyNameEnum enemyName)
        {
            GameObject enemyPrefab = Resources.Load<GameObject>($"EnemyPrefabs/{enemyName}");
            GameObject enemy = GameObject.Instantiate(enemyPrefab);
            enemy.name = enemy.name.Replace("(Clone)", "");

            BaseEnemy Enemy = EnemyScriptTypeFind(enemy);
            return Enemy;
        }   

        private BaseEnemy EnemyScriptTypeFind(GameObject enemy)
        {
            BaseEnemy baseEnemy = enemy.GetComponent<BaseEnemy>();
            switch(baseEnemy)
            {
                case BossEnemy:
                    return (BossEnemy)baseEnemy;
                case MageEnemy:
                    return (MageEnemy)baseEnemy;
                case MeleeEnemy:
                    return (MeleeEnemy)baseEnemy;
                case RangeEnemy:
                    return (RangeEnemy)baseEnemy;
                case TankEnemy:
                    return (TankEnemy)baseEnemy;
                default:
                    return null;
            }
        }
    }

}
