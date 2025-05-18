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
    [CreateAssetMenu(fileName = "Created Enemy Data ScriptableObject", menuName = "Create Enemy Data ScriptableObject")]
    public class EnemyDataScriptableObject : ScriptableObject
    {
        [SerializeField] private BossEnemyData[] bossEnemyDatas;
        public BossEnemyData[] BossEnemyDatas => bossEnemyDatas;

        [SerializeField] private MageEnemyData[] mageEnemyDatas;
        public MageEnemyData[] MageEnemyDatas => mageEnemyDatas;

        [SerializeField] private MeleeEnemyData[] meleeEnemyDatas;
        public MeleeEnemyData[] MeleeEnemyDatas => meleeEnemyDatas;

        [SerializeField] private RangeEnemyData[] rangeEnemyDatas;
        public RangeEnemyData[] RangeEnemyDatas => rangeEnemyDatas;


        [SerializeField] private TankEnemyData[] tankEnemyDatas;
        public TankEnemyData[] TankEnemyDatas => tankEnemyDatas;


    }

}
