using System;

namespace AbstractFactoryPattern
{
    public class Program
    {
        static Vehicle.VehicleFactory vehicleFactory = null;

        public static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to the Abstract Factory Pattern Example");
                Console.WriteLine("1. Create Vehicle Factory");
                Console.WriteLine("2. Create Vehicle");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateVehicleFactory();
                            break;
                        case 2:
                            CreateVehicle();
                            break;
                        case 3:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine();
            }
        }

        static void CreateVehicleFactory()
        {
            Console.WriteLine("Enter the Factory Type Car/Bike:");
            String factoryType = Console.ReadLine();

            switch (factoryType.ToLower())
            {
                case "car":
                    vehicleFactory = Vehicle.VehicleFactory.CreateVehicleFactory("Car");
                    Console.WriteLine("Car Factory created.");
                    break;
                case "bike":
                    vehicleFactory = Vehicle.VehicleFactory.CreateVehicleFactory("Bike");
                    Console.WriteLine("Bike Factory created.");
                    break;
                default:
                    Console.WriteLine("Invalid factory type entered.");
                    break;
            }
        }

        static void CreateVehicle()
        {
            if (vehicleFactory == null)
            {
                Console.WriteLine("Please create a vehicle factory first.");
                return;
            }

            Console.WriteLine("Enter Sports/Regular :");
            String reqVehicle = Console.ReadLine();

            IVehicle vehicle = vehicleFactory.GetVehicle(reqVehicle);
            if (vehicle != null)
            {
                Console.WriteLine("Vehicle created: " + vehicle.GetType().Name);
                Console.WriteLine("Horsepower: " + vehicle.horsePower());
            }
            else
            {
                Console.WriteLine("Invalid vehicle type entered.");
            }
        }
    }
}
