using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemys.Data.BossEnemyData;
using Enemys.Data.MageEnemyData;
using Enemys.Data.MeleeEnemyData;
using Enemys.Data.RangeEnemyData;
using Enemys.Data.TankEnemyData;

namespace Enemys.DataScriptableObject
{
    public class EnemyDataScriptableObject : ScriptableObject
    {
        [SerializeField] private BossEnemyData[] bossEnemyDatas;
        [SerializeField] private MageEnemyData[] mageEnemyDatas;
        [SerializeField] private MeleeEnemyData[] meleeEnemyDatas;
        [SerializeField] private RangeEnemyData[] rangeEnemyDatas;
        [SerializeField] private TankEnemyData[] tankEnemyDatas;
        
    }

}
