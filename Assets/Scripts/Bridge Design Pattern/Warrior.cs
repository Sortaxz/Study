using System.Collections;
using System.Collections.Generic;
using KarakterInterfaces;
using UnityEngine;

namespace BridgeDesignPatter
{
    public class Warrior : Karakter
    {
        public Warrior(IAttackMechanism attackMechanism) : base(attackMechanism)
        {
            
        }

        public override void CharacterAttack()
        {
            attackMechanism.Attack();
        }
    }

}
