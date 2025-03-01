using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    internal class DefenceCharacter : CharacterFactoryBuilder
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
            SetCharacterName("Erkin");
            SetCharacterHealt(50);
            SetCharacterDamage(30);
            SetCharacterShield(100);
            SetCharacterSpeed(70);
        }
    }

}
