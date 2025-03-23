using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public abstract class BaseEnemy :MonoBehaviour,IBaseEnemy
    {
        private GameObject targetPosition;
        private Vector3 newPos;

        private string _enemyName;
        public string EnemyName => _enemyName;

        private float _enemyHealt;
        public float EnemyHealt => _enemyHealt;

        private int _enemyShield;
        public int EnemyShield => _enemyShield;

        private float _enemySpeed;
        public float EnemySpeed => _enemySpeed;

        private int _enemyDamage;
        public int EnemyDamage => _enemyDamage;

        private int _enemyAttack;
        public int EnemyAttack {get {return _enemyAttack;} set {_enemyAttack = value;} }

        private int _enemyDefense;
        public int EnemyDefense => _enemyDefense;


        public void EnemyMove(GameObject targetPosition)
        {
            this.targetPosition = targetPosition;
        }

        public void SetEnemyAttack(int attack)
        {
            _enemyAttack = attack;
        }

        public void SetEnemyDefense(int defense)
        {
            _enemyDefense = defense;
        }

        public void SetEnemyHealt(float healt)
        {
            _enemyHealt = healt;
        }

        public void SetEnemyPosition(Vector3 newPos)
        {
            this.newPos = newPos;
        }

        public void SetEnemySpeed(float speed)
        {
            _enemySpeed = speed;
        }

        public void SetEnemyName(string name)
        {
            _enemyName = name;
        }

        public void SetEnemyShield(int shield)
        {
            _enemyShield = shield;
        }

        public void SetEnemyDamage(int damage)
        {
            _enemyDamage = damage;
        }


    }

}
