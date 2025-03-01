using System.Collections;
using System.Collections.Generic;
using Characters;
using Enemys;
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

    void Awake()
    {
        /*
        archerEnemy = CreateEnemy(EnemyType.Mage);
        for (int i = 0; i < 10; i++)
        {
            archerEnemy.EnemyClone($"Clone-{i}");
        }
        */
        attackCharacter =  CreateCharacter(CharacterType.Defence);
        CloneCharacter(attackCharacter,"DefenceCharacter-1");
    }

    void Start()
    {
        
        
       
    }

    void Update()
    {
        
    }

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
}
