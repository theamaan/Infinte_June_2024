using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryPattern.ConcreteClasses;

namespace AbstractFactoryPattern.Vehicle
{
    public class BikeFactory : VehicleFactory
    {
        public override IVehicle GetVehicle(string vehicleType)
        {
            if (vehicleType.Equals("Regular"))
            {
                return new RegularBike();
            }
            else if (vehicleType.Equals("Sports"))
            {
                return new SportsCar();
            }
            else
            {
                return null;
            }
        }
    }
}
