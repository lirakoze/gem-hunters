using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Player
    {
        public string Name { get; }
        public Position Position { get; set; }
        public int GemCount { get; set; }

        public Player(string name, Position position)
        {
            Name = name;
            Position = position;
            GemCount = 0;
        }

        public void Move(char direction)
        {

            int newX = Position.X;
            int newY = Position.Y;

            if (direction == 'U')
            {
                newX--;
            }
            else if (direction == 'D')
            {
                newX++;
            }
            else if (direction == 'L')
            {
                newY--;
            }
            else if (direction == 'R')
            {
                newY++;
            }
            //Uodating the Position coordinates
            Position = new Position(newX, newY);
        }
    }
}
