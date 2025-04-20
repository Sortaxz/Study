using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Bullet
{
    public class BaseEnemyBullet : MonoBehaviour
    {
        protected GameObject bulletTarget;

        protected Rigidbody2D rb2D;

        private AudioClip fireSound;

        private ParticleSystem fireParticleEffect;

        protected float bulletDamage;

        protected float bulletLifeTime;
        protected int bulletSpeed;

        void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        public virtual void SetBulletTarget(GameObject target)
        {
            bulletTarget = target;
        }

        public void SetBulletDamage(float damage)
        {
            bulletDamage = damage;
        }
    }

}
