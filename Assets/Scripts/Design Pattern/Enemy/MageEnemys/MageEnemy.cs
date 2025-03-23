
namespace Enemys
{
    public class MageEnemy : EnemyFactoryBuilder
    {
        public override IEnemyAttack CreateEnemyAttack()
        {
            return new MageEnemyAttack();
        }

        public override IEnemyDefence CreateEnemyDefence()
        {
            return new MageEnemyDefence();
        }

        public override IEnemyMovement CreateEnemyMovement()
        {
            return new MageEnemyMovement();
        }

        protected override void SetDefaultStats()
        {
            SetName("Mage");
            SetHealth(100);
            SetDamage(70);
            SetSpeed(30);
            SetShield(50);
        }
    }

}
