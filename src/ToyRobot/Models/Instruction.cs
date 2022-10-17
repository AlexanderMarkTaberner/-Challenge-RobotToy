// Copyright Alexander Mark Taberner - 2022

using System.Numerics;

namespace ToyRobot.Models
{ 
    public class Instruction
    {
        public Command CommandType { get; private set; }

        //Nullable types as only PLACE command requires position and cardinal
        public Vector2? Position { get; private set; }
        public Cardinal? CardinalType { get; private set; } 

        public Instruction(Command commandType, Vector2? position = null, Cardinal? cardinalType = null)
        {
            CommandType = commandType;
            Position = position;
            CardinalType = cardinalType;
        }
    }
}
