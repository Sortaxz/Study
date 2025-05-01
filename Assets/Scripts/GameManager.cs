using System.Collections;
using System.Collections.Generic;
using Balance;
using Enemy;
using EnemyCoin.Factory;
using EnemyFactorys;
using Towers;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }


    [SerializeField] private GameObject towerBullet;
    EnemyFactory enemyFactory;

    [SerializeField] private Tower[] towers;
    private TowerCreator towerCreator;

    private BalanceOperations balanceOperations;
    public BalanceOperations BalanceOperations => balanceOperations;
    
    void Awake()
    {
        enemyFactory = new EnemyFactory();
        towerCreator =  new TowerCreator();
        balanceOperations = new BalanceOperations();
    }   

    void Update()
    {




        if (Input.GetKeyDown(KeyCode.X))
        {
            int randomIndex = Random.Range(0, GameUIManager.Instance.EnemyPositions.Length);
            BossEnemy bossEnemy1 = enemyFactory.Create(EnemyNameEnum.BossEnemy_1, GameUIManager.Instance.EnemyPositions[0].position) as BossEnemy;
            enemyFactory.SaveEnemyTypeFindToList(bossEnemy1);
            bossEnemy1.SetEnemyAttack(null, 500, 1000);
            bossEnemy1.SetTargetMovement(GameUIManager.Instance.Target.transform.position);

        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            CreateTower();

        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            towerCreator.TowersReset();
            //enemyFactory.EnemyFunctionStop();
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            enemyFactory.EnemyFunctionStart();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            towers = towerCreator.GetTowerList();
            foreach (var item in towers)
            {
                item.TowerFunctionPause();
            }
        }
        
        if(Input.GetKeyDown(KeyCode.G))
        {
            //EnemyCoinFactory enemyCoinFactory = new EnemyCoinFactory();
            //enemyCoinFactory.EnemyCoinCreate(EnemyCoin.NameEnum.EnemyCoinNameEnum.EnemCoin_1,100);
            /*
            foreach (var item in towers)
            {
                item.TowerFunctionResume();
            }
            */
        }

        if (Input.GetMouseButtonDown(0))
        {
            
            /*
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(newPos.y < 1 && newPos.y > -3f)
            {
                CreateTower(newPos);
                A();
            }
            */
        }

    }



    private void CreateTower()
    {

        ArcherTower archerTower = towerCreator.Create(new ArcherTowerFactory(), TowerName.ArcherTower_1, Vector2.zero) as ArcherTower;
        
        
    }

    public void A()
    {
        towers = towerCreator.GetTowerList();
    }

    private void CreateTower(Vector2 pos)
    {

        ArcherTower archerTower = (ArcherTower)towerCreator.Create(new ArcherTowerFactory(), TowerName.ArcherTower_1, Vector2.zero);
        archerTower.SetTowerPosition(new Vector3(pos.x, pos.y, -1));
        archerTower.SetTowerName(archerTower.name);
    }



    public  void GameOver()
    {
        enemyFactory.EnemyReset();
        towerCreator.TowersReset();
        UIManager.Instance.OpenLoseFinalPanel();
    }

    public static void GameWon()
    {
       UIManager.Instance.OpenWinFinalPanel();
        
    }

    public void CoinIncrease(int coinIncreaseValue)
    {
        print("çalişiyor");
        balanceOperations.CoinValueIncrease(coinIncreaseValue);
    }




}
