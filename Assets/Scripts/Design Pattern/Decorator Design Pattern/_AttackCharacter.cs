using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecoratorDesignPattern
{
    public class _AttackCharacter : _Character
    {
        public override void Attack()
        {
            Debug.Log("Atak karakteri saldiriyor");

        }
    }

}

