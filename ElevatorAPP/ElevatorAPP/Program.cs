using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElevatorAPP
{
    class Program
    {

        private const string QUIT = "q";

        public static void Main(string[] args)
        {
        Start:
            int floor; string floorInput;
            IElevator elevator;
            floorInput = "5";
            if (Int32.TryParse(floorInput, out floor))
            {
                elevator = new Elevator(floor);
            }
            else
            {
                Console.WriteLine("That' doesn't make sense...");
                Console.Beep();
                Thread.Sleep(2000);
                Console.Clear();
                goto Start;
            }
            string input = string.Empty;

            while (input != QUIT)
            {
                Console.WriteLine("Please press which floor you would like to go to");

                input = Console.ReadLine();
                if (Int32.TryParse(input, out floor))
                    elevator.FloorPress(floor);
                else if (input == QUIT)
                    Console.WriteLine("GoodBye!");
                else
                    Console.WriteLine("You have pressed an incorrect floor, Please try again");
            }
        }
    }
    
}
