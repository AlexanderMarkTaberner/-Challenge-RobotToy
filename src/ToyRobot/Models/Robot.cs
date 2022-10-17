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

        /// <summary>
        /// Moves the robot forward one space.
        /// </summary>
        /// <param name="table"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void Move(Table table)
        {
            var newPos = Position + OrdinalAmount();
            if (table.validPosition(newPos))
            {
                Position = newPos;

            } 
            else
            {
                throw new InvalidOperationException("The Robot's new position is not on the table! Ignoring Instruction!");
            }
        }

        /// <summary>
        /// Turns the robot left or right dependent on input (-1 is left, 1 is right)
        /// </summary>
        /// <param name="dir"></param>
        public void Turn(int dir)
        {
            Direction += dir;
            // Overflow ENUM correction - could be better 
            if (((int)Direction) < 0) Direction = Cardinal.WEST;
            else if (((int)Direction) > 3) Direction = Cardinal.NORTH;
        }

        /// <summary>
        /// Replaces position and direction for the start of the Robots actions.
        /// </summary>
        /// <param name="instruction"></param>
        public void Place(Instruction instruction, Table table)
        {
            if (!table.validPosition((Vector2)instruction.Position)) throw new InvalidDataException("The start position is off the table! exiting application.");
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
