using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponInterfaces;

namespace Weapons
{
    public class Weapon : MonoBehaviour,IWeaponComposit
    {
        private static List<IWeaponComponent> weaponComponents;

        static Weapon()
        {
            weaponComponents = new List<IWeaponComponent>();
        }

        void Awake()
        {
            weaponComponents.Add( GetComponentInChildren<WeaponTrigger>());
            weaponComponents.Add( GetComponentInChildren<WeaponBody>());

            Work();
        }

        public void Work()
        {
            print("Silah çalişiyor");
            foreach (var weapon in weaponComponents)
            {
                weapon.Work();
            }
        }

        public void AddComponent(IWeaponComponent weaponComponent)
        {
            weaponComponents.Add(weaponComponent);
        }

        
    }

}

