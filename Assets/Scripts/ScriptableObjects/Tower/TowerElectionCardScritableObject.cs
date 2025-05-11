using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerElection.Scriptable
{
    [CreateAssetMenu(fileName = "Created TowerElection ScriptableObject", menuName = "Create TowerElection ScriptableObject")]
    public class TowerElectionCardScritableObject : ScriptableObject
    {
        public TowerElectionSprite[] towerElectionSprites;
    }
}

[Serializable]
public class TowerElectionSprite
{
    public Sprite[] towerElectionSprite;
}
