using System;
using UnityEngine;

namespace Enemys.Data
{
    public class EnemyData
    {
        [Header("Enemy Property")]

        [Space]
        [Space]

        public string EnemyName;
        public float EnemyHealt;
        public float EnemyMaxHealt;

        public Sprite EnemySprite;

        public float EnemySpeed;
        public float EnemyMaxSpeed;

        public float EnemyAttack;
        public float EnemyMaxAttack;

        public int EnemyShield;
        public int EnemyMaxShield;

        public int EnemyDamage;
        public int EnemyMaxDamage;

        public int EnemyDefense;
        public int EnemyMaxDefense;

        public int EnemyLevel;

        [Header("Enemy Bullet")]

        [Space]
        [Space]
        public string EnemyBulletName;
        public int EnemyBulletCount;

    }

}
