using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleApp
{
    class EqualIntegers
    {
        static void Main(string[] args)
        {
            CheckEqualIntegers();
            CheckPositiveNumber();
            PerformArithmeticOperations();
            Subtract.add();
            swapTwoNumber();
            pattern();
        }

        static void CheckEqualIntegers()
        {
            Console.WriteLine("Please enter the first integer:");
            int integerOne = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the second integer:");
            int integerTwo = Convert.ToInt32(Console.ReadLine());

            if (integerOne == integerTwo)
            {
                Console.WriteLine("The numbers are equal.");
            }
            else
            {
                Console.WriteLine("The numbers are not equal.");
            }
            Console.ReadLine();
        }
        static void CheckPositiveNumber()
        {
            Console.WriteLine("Please Enter a Number:");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number > 0)
            {
                Console.WriteLine("The Number is a Positive Number.");
            }
            else
            {
                Console.WriteLine("The Number is a Negative Number.");
            }
            Console.ReadLine();
        }
        static void PerformArithmeticOperations()
        {
            Console.WriteLine("Please enter the first number:");
            double numberOne = Convert.ToDouble(Console.ReadLine());


            Console.WriteLine("Please enter the second number:");
            double numberTwo = Convert.ToDouble(Console.ReadLine());


            double addition = numberOne + numberTwo;
            Console.WriteLine("The addition of the two numbers is: " + addition);

            double subtraction = numberOne - numberTwo;
            Console.WriteLine("The subtraction of the two numbers is: " + subtraction);

            double multiplication = numberOne * numberTwo;
            Console.WriteLine("The multiplication of the two numbers is: " + multiplication);

            if (numberTwo != 0)
            {
                double division = numberOne / numberTwo;
                Console.WriteLine("The division of the two numbers is: " + division);
            }
            else
            {
                Console.WriteLine("Division by zero is not allowed.");
            }
            Console.ReadLine();
        }
        static void swapTwoNumber()
        {
            Console.WriteLine("Please Enter the first number:");
            int numberOne = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter the second number:");
            int numberTwo = Convert.ToInt32(Console.ReadLine());

            int temp = numberOne;
            numberOne = numberTwo;
            numberTwo = temp;

            Console.WriteLine("The swapped first value is " + numberOne + " and the second value is " + numberTwo);
            Console.ReadLine();
        }
        static void pattern()
        {
            Console.Write("Enter a digit: ");
            int testData = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write(testData + " ");
                    }
                    else
                    {
                        Console.Write(testData);
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        } 
    }
}
