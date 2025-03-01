using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemys
{
    public class EnemyCreator
    {
        public static Enemy Creator(EnemyType enemyType)
        {
            EnemyFactoryBuilder baseEnemy = enemyType switch
            {
                EnemyType.Archer => new ArcherEnemy(),
                EnemyType.Mage => new MageEnemy(),
                _ => default
            };


            return baseEnemy.Build(enemyType);
        }

        
    }

}
