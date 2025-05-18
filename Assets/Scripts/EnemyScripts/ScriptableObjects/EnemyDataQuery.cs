using System.Collections;
using System.Collections.Generic;
using Enemys.Data;
using UnityEngine;

namespace Enemy.Data.Querys
{
    public class EnemyDataQuery
    {

        public int EnemyFromEnemyListQuery(EnemyData[] enemyDatas, string enemyName)
        {
            int index = 0;
            for (int i = 0; i < enemyDatas.Length; i++)
            {
                if (enemyDatas[i].EnemyName == enemyName)
                    index = i;
            }

            return index;   
        }


        

    }



}
