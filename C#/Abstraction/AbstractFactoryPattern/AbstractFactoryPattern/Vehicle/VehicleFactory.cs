using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.Vehicle
{
    public abstract class VehicleFactory
    {
        public abstract IVehicle GetVehicle(String vehicleType);
        public static VehicleFactory CreateVehicleFactory(String factoryType)
        {
            if (factoryType.Equals("Car"))
            {
                return new CarFactory();
            }
            else if (factoryType.Equals("Bike"))
            {
                return new BikeFactory();
            }
            else
            {
                return null;
            }
        }
    }
}
