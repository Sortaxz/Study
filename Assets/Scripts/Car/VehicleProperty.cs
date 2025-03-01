using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle
{
    namespace Vehicle_Property
    {
        public class VehicleProperty : MonoBehaviour
        {
            private int healt;
            internal int Healt { get => healt;set => healt = value; }
            private int speed;
            internal int Speed { get => speed; set => speed = value; }
        }

    }
}

