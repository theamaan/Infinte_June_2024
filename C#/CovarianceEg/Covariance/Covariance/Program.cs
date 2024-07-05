using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covariance
{

    public class Person { }
    public class Employees : Person { }
    public class Manager : Employees { }

    delegate Person personDelegate(Employees emp);
    class Program
    {
        static void Main(string[] args)
        {
            var personObj = new Person();
            var empObj = new Employees();
            var mgrObj = new Manager();

            //assigning more dervied employee/Manager object to a lesser derived personObject
            personObj = empObj;
            personObj = mgrObj;
            empObj = mgrObj;

            //ContraVariance
            personDelegate pd = GreetingPerson; //Contravariance
            pd((Employees)personObj);//assigning less dervied employee object to a more derived personObject
            Console.Read();
        }
        static Person GreetingPerson(Person p)
        {
            Console.WriteLine("HELLO " + p);
            return p;
        }
    }
}
