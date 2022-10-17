// Copyright Alexander Mark Taberner - 2022

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.IO;
using ToyRobot.Models;
using ToyRobot.Services;

namespace ToyRobot.Tests.Services
{
    public class SimulationTests
    {
        

        [Test]
        public void WithValidinstrucitons_SimulationRuns_ReturnsValidResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<Simulation>>();

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    {"path", "TestExamples/tests.txt"}
                }
            ).Build();

            // Result should be (1,2)
            var instructions = new List<Instruction>
            {
                new Instruction(Command.PLACE, new System.Numerics.Vector2(0,0), Cardinal.NORTH),
                new Instruction(Command.MOVE),
                new Instruction(Command.RIGHT),
                new Instruction(Command.MOVE),
                new Instruction(Command.LEFT),
                new Instruction(Command.MOVE),
                new Instruction(Command.REPORT)
            };

            var message = "REPORT: \nOutput: 1,2,NORTH";

            var simulation = new Simulation(loggerMock.Object, configuration);

            // Act
            simulation.RunSimulation(instructions);

            // Assert
            loggerMock.Verify(
                m => m.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Output: 1,2,NORTH")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once
            );
        }

        [Test]
        public void WithInvalidPlaceinstrucitons_SimulationRuns_ReturnsException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<Simulation>>();

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    {"path", "TestExamples/tests.txt"}
                }
            ).Build();

            // Result should be (1,2)
            var instructions = new List<Instruction>
            {
                new Instruction(Command.PLACE, new System.Numerics.Vector2(-1,0), Cardinal.NORTH),
                new Instruction(Command.MOVE),
                new Instruction(Command.RIGHT),
                new Instruction(Command.MOVE),
                new Instruction(Command.LEFT),
                new Instruction(Command.MOVE),
                new Instruction(Command.REPORT)
            };

            var message = "REPORT: \nOutput: 1,2,NORTH";

            var simulation = new Simulation(loggerMock.Object, configuration);
            try
            {
                // Act
                simulation.RunSimulation(instructions);
            } catch (Exception e)
            {
                // Assert
                Assert.That(e, Is.TypeOf<InvalidDataException>());
            }
        }

        [Test]
        public void WithValidinstrucitonsInvalidMove_SimulationRuns_ReturnsValidResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<Simulation>>();

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    {"path", "TestExamples/tests.txt"}
                }
            ).Build();

            // Result should be (1,2)
            var instructions = new List<Instruction>
            {
                new Instruction(Command.PLACE, new System.Numerics.Vector2(0,0), Cardinal.NORTH),
                new Instruction(Command.MOVE),
                new Instruction(Command.LEFT),
                new Instruction(Command.MOVE),
                new Instruction(Command.LEFT),
                new Instruction(Command.MOVE),
                new Instruction(Command.REPORT)
            };

            var message = "REPORT: \nOutput: 1,2,NORTH";

            var simulation = new Simulation(loggerMock.Object, configuration);

            // Act
            simulation.RunSimulation(instructions);

            // Assert
            loggerMock.Verify(
                m => m.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Output: 0,0,SOUTH")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once
            );
        }
    }
}
