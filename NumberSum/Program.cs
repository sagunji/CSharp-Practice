using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********** Program 1: Sum of individual numbers ***********\n\n");
            ConsoleKeyInfo info;
            do
            {
                Calculator calculator = new Calculator();
                string value = calculator.getUserInput();
                calculator.calculate(value);
                calculator.displayResult();
                Console.WriteLine("Press any key to continue or press Esc...");
                info = Console.ReadKey(true);
                Console.WriteLine();
            } while (info.Key != ConsoleKey.Escape);
           
            Console.WriteLine("You have exited the program.");
            Console.ReadKey();
        }
    }
}
