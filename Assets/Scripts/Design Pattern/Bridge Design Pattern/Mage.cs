using System.Collections;
using System.Collections.Generic;
using KarakterInterfaces;
using UnityEngine;

namespace BridgeDesignPatter
{
    public class Mage : Karakter
    {
        public Mage(IAttackMechanism attackMechanism) : base(attackMechanism)
        {
        }

        public override void CharacterAttack()
        {
            attackMechanism.Attack();
        }
    }

}
