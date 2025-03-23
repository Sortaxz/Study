using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecoratorDesignPattern
{
    public class _DefenseCharacter : _Character
    {
        public override void Attack()
        {
            Debug.Log("Defense karakteri saldiriyor");
        }
    }

}

