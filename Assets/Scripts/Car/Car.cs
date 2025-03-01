using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vehicle.Vehicle_Property;
using Vehicle_Interfaces;

namespace Vehicle
{
    namespace Vehicle_Car
    {
        public class Car : VehicleProperty, ILandVehicleMovement
        {
            static Car()
            {
                print("oluştu");
            }

            ~Car()
            {
                print("yok oldu");
            }


            public void LandMovement()
            {
            }

        }

    }
}
