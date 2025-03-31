using System.Collections;
using System.Collections.Generic;
using Enemy;
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

    EnemyFactory enemyFactory;


    void Awake()
    {
        enemyFactory = new EnemyFactory();
    }

    void Update()
    {




        if (Input.GetKeyDown(KeyCode.X))
        {
            int randomIndex = Random.Range(0, GameUIManager.Instance.EnemyPositions.Length);
            BossEnemy bossEnemy1 = enemyFactory.Create(EnemyNameEnum.BossEnemy_1, GameUIManager.Instance.EnemyPositions[0].position) as BossEnemy;
            enemyFactory.SaveEnemyTypeFindToList(bossEnemy1);
            bossEnemy1.SetEnemyAttack(null, 500, 1000);
            bossEnemy1.SetTargetMovement(GameUIManager.Instance.Target.position);

        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            TowerCreator towerCreator = new TowerCreator();
            towerCreator.Create(new FireTowerFactory(), TowerName.FireTower_2);

        }

        // if(Input.GetKeyDown(KeyCode.C))
        // {
        //     WindowManager windowManager = new WindowManager();
        //     windowManager.MinimizeWindow();
        // }

        if (Input.GetMouseButtonDown(0))
        {
            /*
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TowerCreator towerCreator = new TowerCreator();
            ArcherTower archerTower = (ArcherTower)towerCreator.Create(new ArcherTowerFactory(),TowerName.ArcherTower_1);
            archerTower.SetTowerPosition(new Vector3(newPos.x, newPos.y,-1));
            archerTower.SetTowerName(archerTower.name);
            */
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
*/
    #endregion

}
