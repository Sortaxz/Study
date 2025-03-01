using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemys
{
    public abstract class EnemyFactoryBuilder
    {
        protected Enemy enemy;

        public Enemy Build(EnemyType enemyType)
        {
            string enemyPrefabName = enemyType switch
            {
                EnemyType.Archer => "Archer",
                EnemyType.Mage => "Mage",
                _=> default
            };

            GameObject enemyGameObject = GameObject.Instantiate(Resources.Load<GameObject>($"Prefab/{enemyPrefabName}Enemy"));
            enemy = enemyGameObject.AddComponent<Enemy>(); // MonoBehaviour olan Enemy'yi ekliyoruz.
            enemy.enemyAttack = CreateEnemyAttack();
            enemy.enemyDefence = CreateEnemyDefence();
            enemy.enemyMovement = CreateEnemyMovement();
            SetDefaultStats();
            return enemy;
        }
        

        public abstract IEnemyMovement CreateEnemyMovement();
        public abstract IEnemyAttack CreateEnemyAttack();
        public abstract IEnemyDefence CreateEnemyDefence();
        protected abstract void SetDefaultStats();

        protected void SetName(string name) => enemy.SetEnemyName(name);
        protected void SetHealth(int health) => enemy.SetEnemyHealt(health);
        protected void SetDamage(int damage) => enemy.SetEnemyDamage(damage);
        protected void SetSpeed(int speed) => enemy.SetEnemySpeed(speed);
        protected void SetShield(int shield) => enemy.SetEnemyShield(shield);
    }

}
