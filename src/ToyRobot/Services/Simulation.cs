// Copyright Alexander Mark Taberner - 2022

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Numerics;
using ToyRobot.Models;
using ToyRobot.Services.Interfaces;

namespace ToyRobot.Services
{
    public class Simulation:ISimulation
    {
        private Table Table;
        private Robot RobotToy;

        private ILogger<Simulation> _logger;
        private IConfiguration _configuration;

        public Simulation(ILogger<Simulation> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            Table = string.IsNullOrEmpty(_configuration["size"]) ? new Table() : new Table(Int32.Parse(_configuration["size"]));
            RobotToy = new Robot();
        }

        public void run(IEnumerable<Instruction> instructions)
        {
            foreach(Instruction instruction in instructions)
            {
                switch (instruction.CommandType)
                {
                    case Command.PLACE:
                        if (!Table.validPosition((Vector2)instruction.Position)) throw new InvalidDataException("The start position is off the table! exiting application.");
                        RobotToy.Place(instruction);
                        break;

                    case Command.MOVE:
                        try
                        {
                            RobotToy.Move(Table);
                        }
                        catch (InvalidOperationException e)
                        {
                            _logger.LogInformation(e.Message);
                        }
                        break;

                    case Command.LEFT:
                        RobotToy.Turn(-1);
                        break;

                    case Command.RIGHT:
                        RobotToy.Turn(1);
                        break;

                    case Command.REPORT:
                        var message = $"Output: {RobotToy.Position.X},{RobotToy.Position.Y},{RobotToy.Direction}";
                        _logger.LogInformation(message);
                        return;
                }
            }
        }
    }
}
