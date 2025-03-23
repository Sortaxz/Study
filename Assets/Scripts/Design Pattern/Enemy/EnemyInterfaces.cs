using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemys
{
    interface IEnemyClone
    {
        Enemy EnemyClone(string name);
    }

    public interface IEnemyFactory
    {
        Enemy CreateEnemy(EnemyType enemyType);
    }

    public interface IEnemyAttack
    {
        void Attack(GameObject target);
    }

    public interface IEnemyDefence
    {
        void AttackDefence();
    }

    public interface IEnemyMovement
    {
        void Movement();
    }


}
