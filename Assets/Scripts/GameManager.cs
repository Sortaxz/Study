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
            
            CreateRandomEnemy();

        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            CreateFireTower(Vector2.zero);
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
            //towers = towerCreator.GetTowerList();
            CoinIncrease(100);
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



    


    public void CreateArcherTower(Vector2 pos)
    {

        ArcherTower archerTower = (ArcherTower)towerCreator.Create(new ArcherTowerFactory(), TowerName.ArcherTower_1, new Vector3(pos.x, pos.y, -1));
        //archerTower.SetTowerPosition(new Vector3(pos.x, pos.y, -1));
        archerTower.SetTowerName(archerTower.name);
    }

    public void CreateFireTower(Vector2 pos)
    {
        FireTower fireTower = (FireTower)towerCreator.Create(new FireTowerFactory(), TowerName.FireTower_1, new Vector3(pos.x, pos.y, -1));
        //fireTower.SetTowerPosition(new Vector3(pos.x, pos.y, -1));
        fireTower.SetTowerName(fireTower.name);
    }

    public void CreateIceTower(Vector2 pos)
    {
        IceTower iceTower = (IceTower)towerCreator.Create(new IceTowerFactory(), TowerName.IceTower_1, new Vector3(pos.x, pos.y, -1));
        //iceTower.SetTowerPosition(new Vector3(pos.x, pos.y, -1));
        iceTower.SetTowerName(iceTower.name);
    }

    public void CreateRandomEnemy()
    {
        int randomCreateIndex = Random.Range(0,4);
        switch (randomCreateIndex)
        {
            
            case 0:
                CreateBossEnemy();    
            break;

            case 1:
                CreateMageEnemy();
            break;
            
            case 2:
                CreateMeleeEnemy();
            break;
            
            case 3:
                CreateRangeEnemy();
            break;
            
            case 4:
                CreateTankEnemy();
            break;

            default:
            break;
        
        }
    }


    public void CreateBossEnemy()
    {
        int randomIndex = Random.Range(0, GameUIManager.Instance.EnemyPositions.Length);
        BossEnemy bossEnemy1 = enemyFactory.Create(EnemyNameEnum.BossEnemy_1, GameUIManager.Instance.EnemyPositions[randomIndex].position) as BossEnemy;
        enemyFactory.SaveEnemyTypeFindToList(bossEnemy1);
        bossEnemy1.SetEnemyAttack(null, 500, 1000);
        bossEnemy1.SetTargetMovement(GameUIManager.Instance.Target.transform.position);
    }

    public void CreateMageEnemy()
    {
        int randomIndex = Random.Range(0, GameUIManager.Instance.EnemyPositions.Length);
        MageEnemy mageEnemy = enemyFactory.Create(EnemyNameEnum.MageEnemy_1, GameUIManager.Instance.EnemyPositions[randomIndex].position) as MageEnemy;
        enemyFactory.SaveEnemyTypeFindToList(mageEnemy);
        mageEnemy.SetEnemyAttack(null, 500, 1000);
        mageEnemy.SetTargetMovement(GameUIManager.Instance.Target.transform.position);
    }

    public void CreateMeleeEnemy()
    {
        int randomIndex = Random.Range(0, GameUIManager.Instance.EnemyPositions.Length);
        MeleeEnemy meleeEnemy = enemyFactory.Create(EnemyNameEnum.MeleeEnemy_1, GameUIManager.Instance.EnemyPositions[randomIndex].position) as MeleeEnemy;
        enemyFactory.SaveEnemyTypeFindToList(meleeEnemy);
        meleeEnemy.SetEnemyAttack(null, 500, 1000);
        meleeEnemy.SetTargetMovement(GameUIManager.Instance.Target.transform.position);
    }

    public void CreateRangeEnemy()
    {
        int randomIndex = Random.Range(0, GameUIManager.Instance.EnemyPositions.Length);
        RangeEnemy rangeEnemy = enemyFactory.Create(EnemyNameEnum.RangeEnemy_1, GameUIManager.Instance.EnemyPositions[randomIndex].position) as RangeEnemy;
        enemyFactory.SaveEnemyTypeFindToList(rangeEnemy);
        rangeEnemy.SetEnemyAttack(null, 500, 1000);
        rangeEnemy.SetTargetMovement(GameUIManager.Instance.Target.transform.position);
    }

    public void CreateTankEnemy()
    {
        int randomIndex = Random.Range(0, GameUIManager.Instance.EnemyPositions.Length);
        TankEnemy tankEnemy = enemyFactory.Create(EnemyNameEnum.TankEnemy_1, GameUIManager.Instance.EnemyPositions[randomIndex].position) as TankEnemy;
        enemyFactory.SaveEnemyTypeFindToList(tankEnemy);
        tankEnemy.SetEnemyAttack(null, 500, 1000);
        tankEnemy.SetTargetMovement(GameUIManager.Instance.Target.transform.position);
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

    //Coin artırma methodu
    public void CoinIncrease(int coinIncreaseValue)
    {
        UIManager.Instance.BalanceOperationsUIControl.SetCoinIncraseText(coinIncreaseValue);
        TowerObjectsUpgradeStateControl();
    }

    public void CoinReduction(int coinReductionValue)   
    {
        print(coinReductionValue);
        UIManager.Instance.BalanceOperationsUIControl.SetCoinValueReductionText(coinReductionValue);
        //TowerObjectsUpgradeStateControl();
    }

    public void TowerObjectsUpgradeStateControl()
    {
        Tower[] towers = towerCreator.GetTowerList();
        for (int i = 0; i < towers.Length; i++)
        {
            bool value = false;
            if(balanceOperations.GetCoinValue() >= towers[i].TowerCost)
            {
                value = true;
            }
            else
            {
                value = false;
            }
            towers[i].TowerUIController.SetTowerUpgradeIconActive(value);
        }
    }




}
