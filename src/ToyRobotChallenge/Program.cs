using System;
using System.IO;

namespace ToyRobotChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = String.Empty;

            Robot robot = new Robot();

            Console.WriteLine("Robot initialised. Enter commands for the Robot: (Q at any time to quit)");

            while (true)
            {
                Console.WriteLine("Enter command for Robot:");
                inputCommand = Console.ReadLine();

                if (inputCommand.ToUpper().Equals("Q"))
                    break;

                Console.WriteLine(robot.command(inputCommand));
                Console.WriteLine();
            }
            Console.WriteLine("Exited - press any key to close");
            Console.ReadLine();
        }
    }
}
