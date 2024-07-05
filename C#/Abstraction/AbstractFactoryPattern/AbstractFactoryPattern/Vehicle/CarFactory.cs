using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryPattern.ConcreteClasses;

namespace AbstractFactoryPattern.Vehicle
{
    public class CarFactory : VehicleFactory
    {
        public override IVehicle GetVehicle(String carType)
        {
            if (carType.Equals("Regular"))
            {
                return new RegularCar();
            }
            else if (carType.Equals("Sports"))
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
