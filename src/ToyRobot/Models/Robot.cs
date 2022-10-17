// Copyright Alexander Mark Taberner - 2022

using System.Collections;
using System.Numerics;

namespace ToyRobot.Models
{
    public class Robot
    {
        public Vector2 Position {get; set;}
        public Cardinal Direction { get; set; }

        public Robot(Vector2 startPosition, Cardinal startDirection)
        {
            Position = startPosition;
            Direction = startDirection;
        }

        public Robot()
        {
            Position = new Vector2(0,0);
            Direction = Cardinal.NORTH;
        }

        internal void Move(Table table)
        {
            var newPos = Position + OrdinalAmount();
            if (table.validPosition(newPos))
            {
                Position = newPos;

            } else
            {
                throw new InvalidOperationException("The Robot's new position is not on the table! Ignoring Instruction!");
            }
        }

        internal void Turn(int dir)
        {
            Direction += dir;
            if (((int)Direction) < 0) Direction = Cardinal.WEST;
            else if (((int)Direction) > 3) Direction = Cardinal.NORTH;
        }

        internal void Place(Instruction instruction)
        {
            Position = (Vector2)instruction.Position;
            Direction = (Cardinal)instruction.CardinalType;
        }

        private Vector2 OrdinalAmount()
        {
            switch (Direction)
            {
                case Cardinal.NORTH:
                    return new Vector2(0, 1);
                case Cardinal.SOUTH:
                    return new Vector2(0, -1);
                case Cardinal.WEST:
                    return new Vector2(-1, 0);
                case Cardinal.EAST:
                    return new Vector2(1, 0);
                default:
                    throw new InvalidDataException("Variable Robot.Direction is not in a valid state");
            }
        }
    }
}
