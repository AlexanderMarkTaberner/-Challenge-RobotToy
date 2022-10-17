// Copyright Alexander Mark Taberner - 2022

using ToyRobot.Models;

namespace ToyRobot.Services.Interfaces
{
    public interface ISimulation
    {
        public void run(IEnumerable<Instruction> instructions);
    }
}
