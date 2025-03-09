using System.Collections;
using System.Collections.Generic;
using AdapterDesignPattern;
using Characters;
using DecoratorDesignPattern;
using Enemys;
using ObjectPoolingDesignPattern;
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

    [SerializeField] private Enemy archerEnemy;
    [SerializeField] private Character attackCharacter;

    [SerializeField] private GameObject bullet;
    [SerializeField] private int bulletSize;
    [SerializeField] private GameObject startBullet;
    void Awake()
    {
        /*
        for (int i = 0; i < bulletSize; i++)
        {
            GameObject newBulletGameObject = Instantiate(bullet);
            newBulletGameObject.SetActive(false);
            BalletObjectPool.AddBullet(newBulletGameObject);
        }
        */
        _Character _Character = new _DefenseCharacterDecorator(new _DefenseCharacter());
        _Character.Attack();

    }

    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
           startBullet = BalletObjectPool.GetBullet();
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            BalletObjectPool.ReturnBullet(startBullet);
        }
        */

    }


    #region  Abstract Factory ve Builder Design Pattern

    //Abstract Factory kullanarak çok class oluşturulduğundan dolayı başka daha düzgün olması bu durum da kullanılan bir
    //Design pattern bulup onu uygulayacağım.
    
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

    
}
