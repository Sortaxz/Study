using System.Collections;
using System.Collections.Generic;
using KarakterInterfaces;
using UnityEngine;

namespace BridgeDesignPatter
{
    public class MagicAttack : IAttackMechanism
    {
        public void Attack()
        {
            Debug.Log("Magic Attack: Fireball!");
        }
    }

}
