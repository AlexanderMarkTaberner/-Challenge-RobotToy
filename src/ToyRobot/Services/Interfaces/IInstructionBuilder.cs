using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
// Copyright Alexander Mark Taberner - 2022

using ToyRobot.Models;

namespace ToyRobot.Services.Interfaces
{
    public interface IInstructionBuilder
    {
        /// <summary>
        /// Verifies and build the instruction list from the input file, 
        /// or throws exception and logs appropriate messages on invalid input.
        /// </summary>
        /// <returns>IEnumerable<Instruction></returns>
        public IEnumerable<Instruction> VerifyAndBuild();
    }
}
