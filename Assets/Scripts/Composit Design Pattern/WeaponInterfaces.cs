using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WeaponInterfaces
{
    public interface IWeaponComponent
    {
        void Work();
    }

    public interface IWeaponComposit 
    {
        void AddComponent(IWeaponComponent weaponComponent);
        void Work();
    }



}
