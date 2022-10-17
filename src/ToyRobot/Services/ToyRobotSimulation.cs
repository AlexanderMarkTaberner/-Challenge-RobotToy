// Copyright Alexander Mark Taberner - 2022

using Microsoft.Extensions.Logging;
using ToyRobot.Services.Interfaces;

namespace ToyRobot.Services
{
    public class ToyRobotSimulation
    {
        private readonly ILogger<ToyRobotSimulation> _logger;
        private readonly IInstructionBuilder _verifyFile;
        private readonly ISimulation _simulation;

        public ToyRobotSimulation(ILogger<ToyRobotSimulation> logger, IInstructionBuilder verifyFile, ISimulation simulation)
        {
            _logger = logger;
            _verifyFile = verifyFile;
            _simulation = simulation;
        }

        public void Execute(CancellationToken stoppingToken = default)
        {
            _simulation.run(_verifyFile.VerifyAndBuild());
        }
    }
}
