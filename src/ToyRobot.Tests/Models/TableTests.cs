// Copyright Alexander Mark Taberner - 2022

using NUnit.Framework;
using ToyRobot.Models;

namespace ToyRobot.Tests.Models
{
    public class TableTests
    {
        [Test]
        public void GivenPositionOnTableValid_TheFunctionValidatesAs_True()
        {

            // Arrange
            var table = new Table();

            // Act
            var result = table.validPosition(new System.Numerics.Vector2(1, 1));

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void GivenPositionOnTableWest_TheFunctionValidatesAs_False()
        {

            // Arrange
            var table = new Table();

            // Act
            var result = table.validPosition(new System.Numerics.Vector2(-1, 1));

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void GivenPositionOnTableEast_TheFunctionValidatesAs_False()
        {

            // Arrange
            var table = new Table();

            // Act
            var result = table.validPosition(new System.Numerics.Vector2(10, 1));

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void GivenPositionOnTableNorth_TheFunctionValidatesAs_False()
        {

            // Arrange
            var table = new Table();

            // Act
            var result = table.validPosition(new System.Numerics.Vector2(1, 10));

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void GivenPositionOnTableSouth_TheFunctionValidatesAs_False()
        {

            // Arrange
            var table = new Table();

            // Act
            var result = table.validPosition(new System.Numerics.Vector2(1, -1));

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
