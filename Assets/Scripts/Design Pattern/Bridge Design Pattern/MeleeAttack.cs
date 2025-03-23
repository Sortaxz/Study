using System.Collections;
using System.Collections.Generic;
using KarakterInterfaces;
using UnityEngine;

namespace BridgeDesignPatter
{
    public class MeleeAttack : IAttackMechanism
    {
        public void Attack()
        {
            Debug.Log("Melee Attack: Sword Slash!");
        }
    }
}
