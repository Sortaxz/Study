
using UnityEngine;

namespace Characters
{
    internal abstract class CharacterFactoryBuilder
    {
        protected Character character;

        internal Character CreateCharacter(CharacterType characterType)
        {
            string characterPrefabName = characterType switch
            {
                CharacterType.Attack => "Attack",
                CharacterType.Defence => "Defence",
                CharacterType.Strengh => "Strengh",
                CharacterType.Mage => "Mage",
                _=> default
            };

            GameObject characterGameObject = GameObject.Instantiate(Resources.Load<GameObject>($"Prefab/{characterPrefabName}Character"));
            character = characterGameObject.AddComponent<Character>();

            character.CharacterAttack = new CharacterAttack();
            character.CharacterDefence = new CharacterDefence();
            character.CharacterMovement = new CharacterMovement();
            
            SetDefaultStats();
            
            return character;
        }

        internal abstract ICharacterMovement CreateChaacterMovement();
        internal abstract ICharacterAttack CreateCharacterAttack();
        internal abstract ICharacterDefence CreateCharacterDefence();

        internal abstract void SetDefaultStats();

        protected void SetCharacterName(string characterName)
        {
            character.SetCharacterName(characterName);
        }

        protected void SetCharacterHealt(int healt)
        {
            character.SetCharacterHealt(healt);
        }

        protected void SetCharacterDamage(int damage)
        {
            character.SetCharacterDamage(damage);
        }

        protected void SetCharacterShield(int shield)
        {
            character.SetCharacterShield(shield);
        }

        protected void SetCharacterSpeed(int speed)
        {
            character.SetCharacterSpeed(speed);
        }

    }
}