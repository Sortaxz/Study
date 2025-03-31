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

    [SerializeField] private Transform target;
    public Transform Target => target;

}
