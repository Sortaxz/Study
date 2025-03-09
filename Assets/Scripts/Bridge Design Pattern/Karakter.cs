using System.Collections;
using System.Collections.Generic;
using KarakterInterfaces;
using UnityEngine;

public abstract class Karakter
{
    protected IAttackMechanism attackMechanism;

    public Karakter(IAttackMechanism attackMechanism)
    {
        this.attackMechanism = attackMechanism; 
    }

    public abstract void CharacterAttack();
}
