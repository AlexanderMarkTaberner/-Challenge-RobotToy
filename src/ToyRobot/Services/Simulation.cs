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

        ///<inheritdoc/>
        public void RunSimulation(IEnumerable<Instruction> instructions)
        {
            foreach(Instruction instruction in instructions)
            {
                switch (instruction.CommandType)
                {
                    case Command.PLACE:
                        RobotToy.Place(instruction, Table);
                        _logger.LogInformation($"PLACE: Robot is starting at ({RobotToy.Position}) Facing ({RobotToy.Direction})");
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
                        _logger.LogInformation($"MOVE: Robot is now at position ({RobotToy.Position})");
                        break;

                    case Command.LEFT:
                        RobotToy.Turn(-1);
                        _logger.LogInformation($"LEFT: Robot is now Facing ({RobotToy.Direction})");
                        break;

                    case Command.RIGHT:
                        RobotToy.Turn(1);
                        _logger.LogInformation($"RIGHT: Robot is now Facing ({RobotToy.Direction})");
                        break;

                    case Command.REPORT:
                        _logger.LogInformation($"REPORT: \nOutput: {RobotToy.Position.X},{RobotToy.Position.Y},{RobotToy.Direction}");
                        break;
                }
            }
        }
    }
}
