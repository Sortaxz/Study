using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    internal class AttackCharacter : CharacterFactoryBuilder
    {
        internal override ICharacterMovement CreateChaacterMovement()
        {
            return new CharacterMovement();
        }

        internal override ICharacterAttack CreateCharacterAttack()
        {
            return new CharacterAttack();
        }

        internal override ICharacterDefence CreateCharacterDefence()
        {
            return new CharacterDefence();
        }

        internal override void SetDefaultStats()
        {
            SetCharacterName("Berkay");
            SetCharacterHealt(50);
            SetCharacterDamage(85);
            SetCharacterShield(50);
            SetCharacterSpeed(70);
        }
    }

}
