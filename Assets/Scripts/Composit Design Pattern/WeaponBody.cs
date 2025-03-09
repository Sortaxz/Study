using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponInterfaces;

namespace Weapons
{
    public class WeaponBody : MonoBehaviour,IWeaponComponent
    {
        public void Work()
        {
            print("Silah'in gövdesi");
        }

        
    }

}

