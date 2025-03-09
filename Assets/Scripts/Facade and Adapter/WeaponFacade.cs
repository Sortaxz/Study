using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FacadeDesignPattern
{
    public class WeaponFacade : MonoBehaviour
    {
        private BulletSystem bulletSystem;
        private WeaponEffectSystem weaponEffectSystem;
        private WeaponAudioSystem weaponAudioSystem;

        public WeaponFacade()
        {
            bulletSystem = new BulletSystem();
            weaponEffectSystem = new WeaponEffectSystem();
            weaponAudioSystem = new WeaponAudioSystem();
        }


        public void PurchaseItem(string item)
        {
            bulletSystem.AddBullet(item);
            weaponAudioSystem.PlaySound("ateş müziği");
            weaponEffectSystem.PlayEffect("ateş");
            Debug.Log($"Purchased: {item}");
        }


    }

    public class BulletSystem
    {
        public void AddBullet(string item) => Debug.Log($"Item added: {item}");
    }

    public class WeaponEffectSystem
    {
        public void PlayEffect(string effect) => Debug.Log($"Playing effect: {effect}");
    }
    
    public class WeaponAudioSystem
    {
        public void PlaySound(string sound) => Debug.Log($"Playing sound: {sound}");
    }

    
}
