using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponInterfaces;

namespace Weapons
{
    public class WeaponTrigger : MonoBehaviour,IWeaponComponent
    {
        public void Work()
        {
            print("Tetiğe basilip ateş edildi");
        }

        
    }
}

