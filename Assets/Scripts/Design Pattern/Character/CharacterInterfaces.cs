using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    internal interface ICharacterMovement
    {
        void Movement();
    }

    internal interface ICharacterAttack
    {
        void Attack();
    }

    internal interface ICharacterDefence
    {
        void Defence();
    }

    public interface ICharacterCreat
    {
        Character CreateCharacter(CharacterType characterType);
    }

    internal interface ICharacterClone
    {
        Character Clone();
    }

}
