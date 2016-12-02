using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Using delegates in callbacks means that the source of the notifications doesn’t need to know
//anything about the class that receives them, allowing the notification receiver to be refactored or
//replaced without the source having to be modified at all.
namespace DelegatesCallBacks
{
    //Defining a Delegate Type
    delegate void NotifyCalculation(int x, int y, int result);

    class Calculator
    {
        //declaration calcListerner
        NotifyCalculation calcListener;

        //constructor argument that takes an instance of the delegate type
        public Calculator(NotifyCalculation listener)
        {
            calcListener = listener;
        }

        //The delegate is called each time the method is invoked
        public int CalculateProduct(int num1, int num2)
        {
            // perform the calculation
            int result = num1 * num2;
            // notify the delegate that we have performed a calc
            //the calcListener here acturelly is a print function, nothing more
            calcListener(num1, num2, result);
            // return the result
            return result;
        }
    }

    class CalculationListener
    {
        public static void CalculationPrinter(int x, int y, int result)
        {
            Console.WriteLine("Calculation Notification: {0} * {1} = {2}",
            x, y, result);
        }
        public static void CalculationPrinter2(int x, int y, int result)
        {
            Console.WriteLine("Calculation Notification: {0} + {1} = {2}",
            x, y, result);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // create a new Calculator, passing in the printer method
            Calculator calc = new Calculator(CalculationListener.CalculationPrinter2);
            // perform some calculations
            calc.CalculateProduct(10, 20);
            calc.CalculateProduct(2, 3);
            calc.CalculateProduct(20, 1);
            // wait for input before exiting
            Console.WriteLine("Press enter to finish");
            Console.ReadLine();
        }
    }
}
