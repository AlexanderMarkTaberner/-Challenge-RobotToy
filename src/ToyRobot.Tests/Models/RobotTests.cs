// Copyright Alexander Mark Taberner - 2022

using NUnit.Framework;
using System.Numerics;
using ToyRobot.Models;

namespace ToyRobot.Tests.Models
{
    public class RobotTests
    {
        Robot RobotToyTest;

        [SetUp]
        public void Setup()
        {
            RobotToyTest = new Robot(new Vector2(0,0), Cardinal.NORTH);
        }

        [Test]
        public void TurnRobotLeft()
        {
            // Arrange & Act
            RobotToyTest.Turn(-1);

            // Assert
            Assert.That(RobotToyTest.Direction, Is.EqualTo(Cardinal.WEST));
        }

        [Test]
        public void TurnRobotRight()
        {
            // Arrange & Act
            RobotToyTest.Turn(1);

            // Assert
            Assert.That(RobotToyTest.Direction, Is.EqualTo(Cardinal.EAST));
        }

        [Test]
        public void TurnRobotRightFiveTimes()
        {
            // Arrange & Act
            RobotToyTest.Turn(5);

            // Assert
            Assert.That(RobotToyTest.Direction, Is.EqualTo(Cardinal.NORTH));
        }

        [Test]
        public void PlaceRobot_withValidPlace()
        {
            // Arrange & Act
            RobotToyTest.Place(new Instruction(Command.PLACE, new Vector2(0,0), Cardinal.NORTH), new Table());

            // Assert
            Assert.That(RobotToyTest.Direction, Is.EqualTo(Cardinal.NORTH));
            Assert.That(RobotToyTest.Position, Is.EqualTo(new Vector2(0, 0)));
        }

        [Test]
        public void PlaceRobot_withInvalidPlace()
        {
            // Arrange & Act
            try
            {
                RobotToyTest.Place(new Instruction(Command.PLACE, new Vector2(-1, -1), Cardinal.NORTH), new Table());
            }
            catch (Exception e)
            {
                // Assert
                Assert.That(e, Is.TypeOf<InvalidDataException>());
            }
        }

        [Test]
        public void MoveRobot_withValidDirection()
        {
            // Arrange & Act
            RobotToyTest.Move(new Table());

            // Assert
            Assert.That(RobotToyTest.Position, Is.EqualTo(new Vector2(0, 1)));
        }

        [Test]
        public void MoveRobot_withInvalidDirection()
        {
            // Arrange
            RobotToyTest.Direction = Cardinal.WEST;

            // Act
            try
            {
                RobotToyTest.Move(new Table());
            } catch (Exception e)
            {
                // Assert
                Assert.That(RobotToyTest.Position, Is.EqualTo(new Vector2(0, 0)));
                Assert.That(e, Is.TypeOf<InvalidOperationException>());
            }
        }
    }
}
