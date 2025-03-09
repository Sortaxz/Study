using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightDesignPattern
{
    public class TreeManager : MonoBehaviour
    {
        void Awake()
        {
            ITree KavakAgaci = TreeFactory.GetTree(TreeType.KavakAgaci,"kavakAgaci",3,"mor","KavakAgaci");
            print(KavakAgaci.Age + " - " + KavakAgaci.Color + " - " + KavakAgaci.Model);
        }
    }

}
