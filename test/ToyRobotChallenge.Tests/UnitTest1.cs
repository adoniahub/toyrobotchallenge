using System;
using Xunit;
using ToyRobotChallenge;

namespace ToyRobotChallenge.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void WhenNotPlacedYet()
        {   
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("REPORT");
            //assert
            
            Assert.Equal("Error: Robot not placed yet", result);
        }

        [Fact]
        public void Report_0_1_N_AfterPlaced_0_0_N_AndSingleMove()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,NORTH");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
            //assert
            Assert.Equal("0,1,NORTH", result);
        }

        [Fact]
        public void Report_0_0_W_AfterPlaced_0_0_N_AndLeftCommand()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 0,0,NORTH");
            result = robot.command("LEFT");
            result = robot.command("REPORT");
            //assert
            Assert.Equal("0,0,WEST", result);
        }

        [Fact]
        public void Test()
        {
            //arrange
            Robot robot = new Robot();
            //act
            string result = robot.command("PLACE 1,2,EAST");
            result = robot.command("MOVE");
            result = robot.command("MOVE");
            result = robot.command("LEFT");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
            //assert
            Assert.Equal("3,3,NORTH", result);
        }

    }
}
