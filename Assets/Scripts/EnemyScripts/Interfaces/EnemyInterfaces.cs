using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public interface IBaseEnemy
    {
        void SetEnemyName(string name);
        void SetEnemyHealt(float healt);
        void SetEnemyShield(int shield);
        void SetEnemySpeed(float speed);
        void SetEnemyDamage(int damage);
        void SetEnemyAttack(int attack);
        void SetEnemyDefense(int defense);
        void SetEnemyPosition(Vector3 newPos);
        void EnemyMove(GameObject targetPosition);

    }


    public interface IBossMovement
    {
        void SetTargetMovement(Vector3 targetPos);
        void RigidBodyMove(Vector3 targetPos);
    }

}
