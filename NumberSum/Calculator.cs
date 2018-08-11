using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSum
{
    class Calculator
    {
        int result = 0;
        public int Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }
        public string getUserInput ()
        {
            Console.Write("Enter a value to sum: ");
            return Console.ReadLine();
        }
        public void calculate(string value)
        {
            int sum = 0;
            foreach (char item in value)
            {
                sum += Convert.ToInt32(Char.GetNumericValue(item));
            }
            Result = sum;
        }
        public void displayResult ()
        {
            Console.WriteLine("The sum of the provided series is: {0}", Result);
        }
    }
}
