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
        public IEnumerable<Instruction> VerifyAndBuild();
    }
}
