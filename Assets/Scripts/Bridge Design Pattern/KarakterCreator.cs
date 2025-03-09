using System.Collections;
using System.Collections.Generic;
using Enemys;
using KarakterEnums;
using KarakterInterfaces;
using UnityEngine;

namespace BridgeDesignPatter
{
    public class KarakterCreator : MonoBehaviour
    {
        public static Karakter CreateKarakter(IAttackMechanism attackMechanism)
        {
            Karakter karakter = null;
            if(attackMechanism is MageEnemyAttack)
            {
                karakter = new Mage(attackMechanism);
            }
            else 
            {
                karakter = new Warrior(attackMechanism);
            }

            return karakter;
        }
    }

}

