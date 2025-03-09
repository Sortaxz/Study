using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    internal class CharacterCreator : ICharacterCreat
    {
        public Character CreateCharacter(CharacterType characterType)
        {
            CharacterFactoryBuilder characterFactoryBuilder = characterType switch
            {
                CharacterType.Attack => new AttackCharacter(),
                _ => default
            };

            

            return characterFactoryBuilder.CreateCharacter(characterType);
        }

    }

}
