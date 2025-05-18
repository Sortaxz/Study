
using UnityEngine;

using Enemy;
using System;
using System.Collections.Generic;
using Enemys.DataScriptableObject;
using EnemyFactorys.TypeEnums;
using Enemy.Data.Querys;

namespace EnemyFactorys
{
    public class EnemyFactory
    {
        private  Dictionary<string, BaseEnemy> enemyPool = new Dictionary<string, BaseEnemy>();
        private Dictionary<string,BaseEnemy> baseEnemies = new Dictionary<string,BaseEnemy>();

        private EnemyDataScriptableObject enemyDataScriptableObject;
        private EnemyDataQuery enemyDataQuery;

        private int createEnemyCount = 0;

        public EnemyFactory()
        {
            if (enemyDataScriptableObject == null)
            {
                enemyDataScriptableObject = Resources.Load<EnemyDataScriptableObject>("ScriptableObjects/Enemy/EnemyDataScriptableObject");
            }

            if (enemyDataQuery == null)
            {
                enemyDataQuery = new EnemyDataQuery();
            }

        }

        public BaseEnemy Create(EnemyNameEnum enemyName,EnemyFactoryType enemyFactoryType,Transform target, Vector3 position)
        {

            if (enemyPool.TryGetValue(enemyName.ToString(), out BaseEnemy enemy))
            {
                BaseEnemy baseEnemy = enemy.EnemyClone();

                /*
                baseEnemy.SetEnemyPosition(position);
                baseEnemy.SetEnemyName(baseEnemy.name,createEnemyCount);
                */

                /*
                    _enemy.EnemyPropertyAdjust(enemyDataScriptableObject);
                */

                FactoryTypeIndexDetermination(enemyFactoryType,enemyName,baseEnemy,target,createEnemyCount,position);

                baseEnemies.Add(baseEnemy.name, baseEnemy);

                createEnemyCount++;
                return baseEnemy;
            }

            GameObject prefab = Resources.Load<GameObject>($"EnemyPrefabs/{enemyName.ToString()}");
            prefab.name = prefab.name.Replace('1', ' ');
            BaseEnemy _enemy = GameObject.Instantiate(prefab).GetComponent<BaseEnemy>();
            FactoryTypeIndexDetermination(enemyFactoryType,enemyName,_enemy,target,createEnemyCount,position);

            /*
            _enemy.SetEnemyPosition(position);
            _enemy.SetEnemyName(_enemy.name,createEnemyCount);
            */



            enemyPool.Add(_enemy.name, _enemy);

            baseEnemies.Add(_enemy.name, _enemy);

            createEnemyCount++;

            return _enemy;

        }

        private void FactoryTypeIndexDetermination(EnemyFactoryType enemyFactoryType,EnemyNameEnum enemyPrefabName,BaseEnemy enemy,Transform target,int enemyNameNumber,Vector3 enemyPosition)
        {
            int index = 0;
            switch (enemyFactoryType)
            {
                case EnemyFactoryType.BoosEnemyFactory:
                    index = enemyDataQuery.EnemyFromEnemyListQuery(enemyDataScriptableObject.BossEnemyDatas, enemyPrefabName.ToString());
                    enemy.EnemyPropertyAdjust(enemyDataScriptableObject.BossEnemyDatas[index],target,enemyNameNumber,enemyPosition);
                    break;
                case EnemyFactoryType.MeleeEnemyFactory:
                    index = enemyDataQuery.EnemyFromEnemyListQuery(enemyDataScriptableObject.MeleeEnemyDatas, enemyPrefabName.ToString());
                    enemy.EnemyPropertyAdjust(enemyDataScriptableObject.MeleeEnemyDatas[index],target,enemyNameNumber,enemyPosition);
                    break;
                case EnemyFactoryType.MageEnemyFactory:
                    index = enemyDataQuery.EnemyFromEnemyListQuery(enemyDataScriptableObject.MeleeEnemyDatas, enemyPrefabName.ToString());
                    enemy.EnemyPropertyAdjust(enemyDataScriptableObject.MeleeEnemyDatas[index],target,enemyNameNumber,enemyPosition);
                    break;
                case EnemyFactoryType.RangeEnemyFactory:
                    index = enemyDataQuery.EnemyFromEnemyListQuery(enemyDataScriptableObject.MeleeEnemyDatas, enemyPrefabName.ToString());
                    enemy.EnemyPropertyAdjust(enemyDataScriptableObject.MeleeEnemyDatas[index],target,enemyNameNumber,enemyPosition);
                    break;
                case EnemyFactoryType.TankEnemyFactory:
                    index = enemyDataQuery.EnemyFromEnemyListQuery(enemyDataScriptableObject.MeleeEnemyDatas, enemyPrefabName.ToString());
                    enemy.EnemyPropertyAdjust(enemyDataScriptableObject.MeleeEnemyDatas[index],target,enemyNameNumber,enemyPosition);
                    break;
                default:
                    break;
            }


        }

       


        internal void SaveEnemyTypeFindToList(BaseEnemy enemy)
        {
            if (!baseEnemies.ContainsKey(enemy.name))
                baseEnemies.Add(enemy.name, enemy);
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

        public void EnemyReset()
        {
            foreach (var item in enemyPool.Values)
            {
                GameObject.Destroy(item.gameObject);
            }
            
            foreach (var item in baseEnemies.Values)
            {
                GameObject.Destroy(item.gameObject);
            }

            enemyPool.Clear();
            baseEnemies.Clear();
        }

    }

}
