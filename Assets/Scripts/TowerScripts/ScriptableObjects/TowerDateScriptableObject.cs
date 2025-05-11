using System.Collections;
using System.Collections.Generic;
using TowerData.Archer;
using TowerData.Fire;
using TowerData.Ice;
using UnityEngine;

namespace Towers.DataScriptableObject
{
    [CreateAssetMenu(fileName = "Created TowerDataScriptableObject", menuName = "Create TowerData ScriptableObject")]
    public class TowerDateScriptableObject : ScriptableObject
    {
        
        [SerializeField] private ArcherTowerData[] archerTowerDatas;
        public ArcherTowerData[] ArcherTowerDatas => archerTowerDatas;
        
        [SerializeField] private FireTowerData[] fireTowerDatas;
        public FireTowerData[] FireTowerDatas => fireTowerDatas;

        [SerializeField] private IceTowerData[] iceTowerDatas;
        public IceTowerData[] IceTowerDatas => iceTowerDatas;
    
    }

}
