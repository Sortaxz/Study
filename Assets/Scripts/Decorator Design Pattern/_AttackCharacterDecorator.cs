using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecoratorDesignPattern
{
    public class _AttackCharacterDecorator : Decorator
    {
        public _AttackCharacterDecorator(_Character character) : base(character)
        {
        }

        public override void Attack()
        {
            base.Attack();
            Debug.Log("Double atak");
        }

    }

}

