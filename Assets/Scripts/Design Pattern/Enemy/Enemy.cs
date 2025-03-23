using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemys
{
    public  class Enemy : MonoBehaviour,IEnemyClone
    {
        #region  Enemy Property
        private string enemyName;
        public string EnemyName => enemyName;
        private int healt;
        public int Healt => healt;
        private int damage;
        public int Damage => damage;
        private int speed;
        public int Speed => speed;
        private int shield;
        public int Shield => shield;


        #endregion

        public IEnemyMovement enemyMovement;
        public IEnemyAttack enemyAttack;
        public IEnemyDefence enemyDefence;

        public void SetEnemyName(string name)
        {
            enemyName = name;
            gameObject.name = enemyName;
        }

        public void SetEnemyHealt(int healt)
        {
            this.healt = healt;
        }
        public void SetEnemyDamage(int damage)
        {
            this.damage = damage;
        }
        public void SetEnemyShield(int shield)
        {
            this.shield = shield;
        }

        public void SetEnemySpeed(int speed)
        {
            this.speed = speed;
        }

        public Enemy EnemyClone(string enemyName)
        {
            GameObject enemyClone = Instantiate(gameObject);
            enemyClone.name = enemyName;
            Enemy enemyScript = enemyClone.GetComponent<Enemy>();
            enemyScript = base.MemberwiseClone() as Enemy;
            return enemyScript;
        }
    }

}
