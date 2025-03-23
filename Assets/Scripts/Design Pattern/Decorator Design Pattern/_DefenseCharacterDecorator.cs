using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecoratorDesignPattern
{
    public class _DefenseCharacterDecorator : Decorator
    {
        public _DefenseCharacterDecorator(_Character character) : base(character)
        {
        }

        public override void Attack()
        {
            base.Attack();
            Debug.Log("Defensif saldisi");
        }

    }

}

