// Copyright Alexander Mark Taberner - 2022

using ToyRobot.Models;

namespace ToyRobot.Services.Interfaces
{
    public interface ISimulation
    {
        /// <summary>
        /// Runs the robot toy simulation with the provided instruction list.
        /// By default the simulation will run on a 5x5 table unless a '-size' 
        /// command line parameter was used to define the size.
        /// </summary>
        /// <param name="instructions"></param>
        public void RunSimulation(IEnumerable<Instruction> instructions);
    }
}
