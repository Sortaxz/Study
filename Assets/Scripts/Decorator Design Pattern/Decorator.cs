using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecoratorDesignPattern
{
    public abstract class Decorator : _Character
    {
        _Character character;
        
        public Decorator(_Character character)
        {
            this.character = character;
        }

        public override void Attack()=> character.Attack();
    
    }

}
