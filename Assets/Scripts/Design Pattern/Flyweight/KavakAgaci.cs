using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightDesignPattern
{
    public class KavakAgaci : MonoBehaviour, ITree
    {
        public int Age { get ; set ; }
        public string Color { get ; set ; }
        public string Model { get ; set ; }

        KavakAgaci kavakAgaci;

        void Awake()
        {
            kavakAgaci = GetComponent<KavakAgaci>();
            
            
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                
            }
        }
    }

}
