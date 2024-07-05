using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.ConcreteClasses
{
    public class SportsBike : IVehicle
    {
        public int horsePower()
        {
            return 200;
        }

    }
}
