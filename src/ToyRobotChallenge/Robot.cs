using System;

namespace ToyRobotChallenge
{
    public class Robot
    {
        public const string OUT_OF_BOUNDS_MESSAGE = "Out of boundary";
        private const int xLowerBoundary = 0;
        private const int yLowerBoundary = 0;

        private int xUpperBoundary = -1;
        private int yUpperBoundary = -1;
        private int xPosition = -1;
        private int yPosition = -1;
        private string direction = string.Empty;
        private bool isPlaced = false;

        // Default table size 5,5 if not supplied
        public Robot()
        {
            xUpperBoundary = 5;
            yUpperBoundary = 5;
        }

        private bool validatePosition()
        {
            if ((xPosition < xLowerBoundary) || (yPosition < yLowerBoundary))
                return false;
            else if ((xPosition > xUpperBoundary) || (yPosition > yUpperBoundary))
                return false;
            else
                return true;
        }

        private string place(string command)
        {
            string result = string.Empty;
            char[] delimiterChars = { ',', ' ' };
            string[] wordsInCommand = command.Split(delimiterChars);

            xPosition = Int32.Parse(wordsInCommand[1]);
            yPosition = Int32.Parse(wordsInCommand[2]);
            direction = wordsInCommand[3];

            if (!validatePosition())
                result = OUT_OF_BOUNDS_MESSAGE;
            else
                isPlaced = true;

            return result;
        }

        private string report()
        {
            return xPosition + "," + yPosition + "," + direction;
        }

        private string move()
        {
            string result = string.Empty;
            int originalX = this.xPosition;
            int originalY = this.yPosition;

            switch (direction)
            {
                case "NORTH":
                    yPosition++; break;
                case "WEST":
                    xPosition--; break;
                case "SOUTH":
                    yPosition--; break;
                case "EAST":
                    xPosition++; break;
            }                

            if (!validatePosition())
            {
                xPosition = originalX;
                yPosition = originalY;
                result = OUT_OF_BOUNDS_MESSAGE;
            }
            return result;
        }

        private void left()
        {
            switch (direction)
            {
                case "NORTH":
                    direction = "WEST"; break;
                case "WEST":
                    direction = "SOUTH"; break;
                case "SOUTH":                
                    direction = "EAST"; break;
                case "EAST":
                    direction = "NORTH"; break;
            }
        }

        private void right()
        {
            switch (direction)
            {
                case "NORTH":
                    direction = "EAST"; break;
               
                case "EAST":
                    direction = "SOUTH"; break;
                
                case "SOUTH":
                    direction = "WEST"; break;
               
                case "WEST":
                    direction = "NORTH"; break;
            }
        }

        public string command(string input)
        {
            string command = input.ToUpper();
            string result = string.Empty;

            try
            {
                if (command.Contains("PLACE"))
                    result = place(command);

                else if (!isPlaced)
                    result = "Error: Not placed yet";

                else if (command.Contains("REPORT"))
                    result = report();

                else if (command.Contains("MOVE"))
                    result = move();

                else if (command.Contains("LEFT"))
                    left();

                else if (command.Contains("RIGHT"))
                    right();

                else
                    result = "Unclear Command";
            }
            catch (Exception)
            {
                result = "Valid commands are:\nPLACE X,Y,Z\nMOVE\nLEFT\nRIGHT\nREPORT";
            }

            return result;
        }
    }
}

