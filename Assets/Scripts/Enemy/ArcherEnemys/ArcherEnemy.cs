using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemys
{
    public class ArcherEnemy : EnemyFactoryBuilder
    {
        public override IEnemyAttack CreateEnemyAttack()
        {
            return new ArcherEnemyAttack();
        }

        public override IEnemyDefence CreateEnemyDefence()
        {
            return new ArcherEnemyDefence();
        }

        public override IEnemyMovement CreateEnemyMovement()
        {
            return new ArcherEnemyMovement();
        }

        protected override void SetDefaultStats()
        {
            SetName("Archer");
            SetHealth(100);
            SetDamage(70);
            SetSpeed(30);
            SetShield(50);
        }
    }
    

}
