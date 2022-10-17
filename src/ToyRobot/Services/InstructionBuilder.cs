// Copyright Alexander Mark Taberner - 2022

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Numerics;
using ToyRobot.Models;
using ToyRobot.Services.Interfaces;

namespace ToyRobot.Services
{
    public class InstructionBuilder:IInstructionBuilder
    {
        private readonly ILogger<InstructionBuilder> _logger;
        private readonly IConfiguration _configuration;

        public InstructionBuilder(ILogger<InstructionBuilder> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IEnumerable<Instruction> VerifyAndBuild()
        {
            string filePath = _configuration["path"];

            var loadedLines = File.ReadAllLines(filePath);
            foreach (var commandLine in loadedLines)
            {
                var commandParts = commandLine.Split(' ');

                if (!Command.TryParse(commandParts[0].ToUpperInvariant(), out Command currentCommand))
                {
                    _logger.LogError($"\"{commandParts[0]}\" is not a valid command type or format, please refer to the README.md document for instructions to construct a command set.");
                    throw new InvalidDataException("Incorrect Command Type");
                }

                if (loadedLines.First() == commandLine)
                {
                    var robotStart = commandParts[1].Split(',');
                    Vector2 startPosition;

                    try
                    {
                        startPosition = new Vector2(Int32.Parse(robotStart[0]), Int32.Parse(robotStart[1]));
                    } 
                    catch (FormatException e)
                    {
                        _logger.LogError($"\"{robotStart[0]},{robotStart[1]}\" is not a valid input or format for starting location, please refer to the README.md document for instructions to construct a command set.");
                        throw e;
                    }

                    if (!Cardinal.TryParse(robotStart[2].ToUpperInvariant(), out Cardinal currentCardinal))
                    {
                        _logger.LogError($"\"{robotStart[2]}\" is not a valid cardinal type or format, please refer to the README.md document for instructions to construct a command set.");
                        throw new InvalidDataException("Incorrect Cardinal Type");
                    }

                    yield return new Instruction(currentCommand, startPosition, currentCardinal);
                } 
                else
                {
                    yield return new Instruction(currentCommand);
                }
            }
        }
    }
}
