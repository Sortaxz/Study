using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public class Character : MonoBehaviour,ICharacterClone
    {
        #region  Enemy Property
        private string characterName;
        internal string CharacterName => characterName;
        private int healt;
        internal int Healt => healt;
        private int damage;
        internal int Damage => damage;
        private int speed;
        internal int Speed => speed;
        private int shield;
        internal int Shield => shield;


        #endregion

        internal ICharacterMovement CharacterMovement{get; set;}
        internal ICharacterAttack CharacterAttack {get; set;}
        internal ICharacterDefence CharacterDefence{get; set;}


        internal void SetCharacterName(string name)
        {
            characterName = name;
            gameObject.name = characterName;
        }

        internal void SetCharacterHealt(int healt)
        {
            this.healt = healt;
        }
        internal void SetCharacterDamage(int damage)
        {
            this.damage = damage;
        }
        internal void SetCharacterShield(int shield)
        {
            this.shield = shield;
        }

        internal void SetCharacterSpeed(int speed)
        {
            this.speed = speed;
        }

        public Character Clone()
        {
            Character characterSciptClone = base.MemberwiseClone() as Character;
            return characterSciptClone;
        }
    }

}
