// Copyright Alexander Mark Taberner - 2022

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ToyRobot.Models;
using ToyRobot.Services;

namespace ToyRobot.Tests.Services
{
    public class InstructionBuilderTests
    {
        [Test]
        public void WithValidInput_VerificationOfFileIs_Valid()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<InstructionBuilder>>();
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    {"path", "TestExamples/tests.txt"}
                }
            ).Build();

            var verifyFile = new InstructionBuilder(loggerMock.Object, configuration);

            // Act
            var moves = verifyFile.VerifyAndBuild();
            moves = moves.ToList();

            // Assert

            Assert.That(moves, Is.Not.Empty);
            Assert.That(moves.Count, Is.EqualTo(5));
            Assert.That(moves.First().CommandType, Is.EqualTo(Command.PLACE));
        }

        [Test]
        public void WithInvalidInput_VerificationOfFileIs_FormatException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<InstructionBuilder>>();
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    {"path", "TestExamples/formatexcept.txt"}
                }
            ).Build();

            var verifyFile = new InstructionBuilder(loggerMock.Object, configuration);

            // Act
            try
            {
                var moves = verifyFile.VerifyAndBuild();
                moves = moves.ToList();
            }
            catch (Exception e)
            {
                // Assert
                Assert.That(e, Is.TypeOf<FormatException>());
                // assert log event is fired
            }
        }

        [Test]
        public void WithInvalidInput_VerificationOfFileIs_InvalidDataException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<InstructionBuilder>>();
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    {"path", "TestExamples/invaliddataexcept.txt"}
                }
            ).Build();

            var verifyFile = new InstructionBuilder(loggerMock.Object, configuration);

            // Act
            try
            {
                var moves = verifyFile.VerifyAndBuild();
                moves = moves.ToList();
            }
            catch (Exception e)
            {
                // Assert
                Assert.That(e, Is.TypeOf<InvalidDataException>());
                // assert log event is fired
            }
        }

        [Test]
        public void WithEmptyInput_VerificationOfFileIs_InvalidDataException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<InstructionBuilder>>();
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    {"path", " "}
                }
            ).Build();

            var verifyFile = new InstructionBuilder(loggerMock.Object, configuration);

            // Act
            try
            {
                var moves = verifyFile.VerifyAndBuild();
                moves = moves.ToList();
            }
            catch (Exception e)
            {
                // Assert
                Assert.That(e, Is.TypeOf<ArgumentException>());
                // assert log event is fired
            }
        }
    }
}