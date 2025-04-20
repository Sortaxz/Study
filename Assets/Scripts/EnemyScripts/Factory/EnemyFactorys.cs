
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
        private Dictionary<string,BaseEnemy> baseEnemies = new Dictionary<string,BaseEnemy>();
        private int createEnemyCount =0;
        public BaseEnemy Create(EnemyNameEnum enemyName, Vector3 position)
        {
            if(enemyPool.TryGetValue(enemyName.ToString(), out BaseEnemy enemy))
            {
                BaseEnemy baseEnemy =  enemy.EnemyClone();
                
                baseEnemy.SetEnemyPosition(position);
                baseEnemy.SetEnemyName(baseEnemy.name,createEnemyCount);
                
                baseEnemies.Add(baseEnemy.name,baseEnemy);

                createEnemyCount++;
                return  baseEnemy;
            }

            GameObject prefab = Resources.Load<GameObject>($"EnemyPrefabs/{enemyName.ToString()}");
            prefab.name = prefab.name.Replace('1',' ');
            BaseEnemy _enemy = GameObject.Instantiate(prefab).GetComponent<BaseEnemy>();
            _enemy.SetEnemyPosition(position);
            _enemy.SetEnemyName(_enemy.name,createEnemyCount);

            enemyPool.Add(_enemy.name,_enemy);

            baseEnemies.Add(_enemy.name,_enemy);

            createEnemyCount++;

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

        //Oluşturulan bütün enemy'leri hareketi ve diğer fonksiyon'ları durdurmamizi sağliyor.
        public void EnemyFunctionPause()
        {
            Debug.Log(baseEnemies.Keys.Count);
            foreach (var item in baseEnemies.Values)
            {
                item.EnemyMovementPause();
            }
        }

        public void EnemyFunctionResume()
        {
            Debug.Log(baseEnemies.Keys.Count);
            foreach (var item in baseEnemies.Values)
            {
                item.EnemyMovementResume();
            }
        }


        public void EnemyFunctionStart()
        {
            Debug.Log(baseEnemies.Keys.Count);
            foreach (var item in baseEnemies.Values)
            {
                item.EnemyMovementStart();
            }
        }

        public void EnemyFunctionStop()
        {
            Debug.Log(baseEnemies.Keys.Count);
            foreach (var item in baseEnemies.Values)
            {
                item.EnemyMovementStop();
            }
        }

    }

}
