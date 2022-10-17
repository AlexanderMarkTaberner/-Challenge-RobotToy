// Copyright Alexander Mark Taberner - 2022

using System.Numerics;

namespace ToyRobot.Models
{
    public class Table
    {
        public int Size { get; private set; }

        public Table()
        {
            Size = 5;
        }

        public Table(int size)
        {
            Size = size;
        }

        /// <summary>
        /// Given a poition, return if it is on the table (true) or off the table (false)
        /// </summary>
        /// <param name="posisiton"></param>
        /// <returns></returns>
        public bool validPosition(Vector2 posisiton)
        {
            return (posisiton.X >= 0 && posisiton.Y >= 0 && posisiton.X <= Size && posisiton.Y <= Size);
        }
    }
}
