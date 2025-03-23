

using UnityEngine;

namespace Enemys
{
    public class MageEnemyAttack : IEnemyAttack
    {
        public void Attack(GameObject target)
        {
            Debug.Log("Düşman Büyücü saldiriyor");
        }
    }

}
