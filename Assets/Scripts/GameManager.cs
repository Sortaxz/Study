using System.Collections;
using System.Collections.Generic;
using AdapterDesignPattern;
using Characters;
using Enemy;
using EnemyFactorys;
using Rewards.Enums;
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

   
    void Awake()
    {
       
    }

    [SerializeField] private GameObject target;
        //Balanced,Swarm,Tank
    [SerializeField] GameObject enemyPrefab;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ArcherTowerFactory archerTowerFactory = new ArcherTowerFactory();
            ArcherTower archerTower = (ArcherTower)archerTowerFactory.Create(TowerName.ArcherTower_1);
            archerTower.SetTowerAttackSpeed(35);
            print(archerTower.TowerAttackSpeed);
            
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            FireTowerFactory fireTowerFactory= new FireTowerFactory();
            fireTowerFactory.Create(TowerName.FireTower_1);
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            IceTowerFactory iceTowerFactory = new IceTowerFactory();
            iceTowerFactory.Create(TowerName.IceTower_1);
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            EnemyFactory enemyFactory = new EnemyFactory();
            BossEnemy enemy =  enemyFactory.Create(EnemyNameEnum.BossEnemy_1) as BossEnemy;
            enemy.SetTargetMovement(new Vector3(10,0,0));
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            RewardController rewardController = new RewardController();
            rewardController.EssenceRewardCreate(EssenceNameEnum.EssenceReward_1);
            rewardController.ItemRewardCreate(ItemNameEnum.ItemReward_1);
        }
    }




    #region  Abstract Factory ve Builder Design Pattern

    //Abstract Factory kullanarak çok class oluşturulduğundan dolayı başka daha düzgün olması bu durum da kullanılan bir
    //Design pattern bulup onu uygulayacağım.

    /*
    public Enemy CreateEnemy(EnemyType enemyType)
    {
        Enemy newEnemyScript = EnemyCreator.Creator(enemyType);
        
        newEnemyScript.gameObject.name = newEnemyScript.EnemyName;
        return newEnemyScript;
    }
    */

    public Character CreateCharacter(CharacterType characterType)
    {
        CharacterCreator characterCreator = new CharacterCreator();
        Character character = characterCreator.CreateCharacter(characterType);
        character.gameObject.name = character.CharacterName;
        return character;
    }

    public void CloneCharacter(Character character,string cloneCharacterName)
    {
        GameObject cloneCharacter = Instantiate(character.gameObject);
        cloneCharacter.name = cloneCharacterName;
        Character cloneCharacterScript = cloneCharacter.GetComponent<Character>();
        cloneCharacterScript = character.Clone(); 
    }

    #endregion

    #region  Adapter Design Patter

    private void AdapterDesignPatter()
    {
        GamepadController gamepadController = new GamepadController();
        IPlayerController playerController = new GamepadAdapter(gamepadController);

        InputControllerAdapter inputControllerAdapter = new InputControllerAdapter(playerController);
    
        inputControllerAdapter.InputMove();
    }

    #endregion

    
}
