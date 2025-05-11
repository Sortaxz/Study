using System.Collections;
using System.Collections.Generic;
using Towers.Position;
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
    [SerializeField] private TowerPosition[] towerPositions;
    public TowerPosition[] TowerPositions => towerPositions;

    //TowerElection objelerini hangisine tıkladıysaniz onu paremetre olarak veriyoruz ve diğer towerelection'ların tıklanilabilirliğini false yapmamizi sağliyor.
    public void AdjustTowerPositionActive(GameObject towerPosition)
    {
        for (int i = 0; i < towerPositions.Length; i++)
        {
            if(towerPositions[i].name != towerPosition.name) towerPositions[i].SetTowerPositionInteractable(false);
        }
    }
    //Bütün towerelection objelerinin tiklanilabilirliğini aktif yapmamizi sağliyor.
    public void SetActiveAllTowerPositionInteractable()
    {
        foreach (var towerPosition in towerPositions)
        {
            if(!towerPosition.IsFull)
            {
                towerPosition.SetTowerPositionInteractable(true);
            }
        }
    }

    


    
}
