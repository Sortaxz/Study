using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    private static GameUIManager instance;
    public static GameUIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameUIManager>();
            }
            return instance;
        }
    }

    [SerializeField] private Transform[] enemyPositions;
    public Transform[] EnemyPositions => enemyPositions;
    
    [SerializeField] private GameObject target;

    public GameObject Target { get { return target; }  set { target = value; } }

    [SerializeField] private Transform towerPositionObjectsParent;
    [SerializeField] private Transform[] towerPositions;
    public Transform[] TowerPositions => towerPositions;

}
