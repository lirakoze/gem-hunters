using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Board
    {
        public Cell[,] Grid { get; }
        public int Gems { get; private set; }


        public Board()
        {
            Grid = new Cell[6, 6];
            Gems = 6;
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            // Initialize the board with empty cells

            for (int i = 0; i <6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Grid[i, j] = new Cell();
                }
            }

            // Add players, player one starts from the top left and player two is placed on the bottom right

            Grid[0, 0].Occupant = "P1";
            Grid[5, 5].Occupant = "P2";


            // Adding 6 gems randomly
            Random rand = new Random();

            for (int i = 0; i < 6; i++)
            {
                int gemX, gemY;
                do
                {
                    //randomly generating xy gem coordinates
                    gemX = rand.Next(6);
                    gemY = rand.Next(6);

                } while (Grid[gemX, gemY].Occupant != "_");

                Grid[gemX, gemY].Occupant = "G";
            }

            //Adding 4 random obstacles
            for (int i = 0; i < 4; i++)
            {
                int oX, oY;
                do
                {
                    //randomly generating xy obstacle coordinates
                    oX = rand.Next(6);
                    oY = rand.Next(6);

                } while (Grid[oX,oY].Occupant!="_");

                Grid[oX,oY].Occupant= "O";

            }

        }

        public void Display()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(Grid[i, j].Occupant + " ");
                }
                Console.WriteLine();
            }
        }

        public bool IsValidMove(Player player, char direction)
        {
            int newX = player.Position.X;
            int newY = player.Position.Y;

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

            // Check if the new position is within the bounds and not an obstacle or another player position

            return newX >= 0 && newX < 6 && newY >= 0 && newY < 6 
                && Grid[newX, newY].Occupant != "O"
                && Grid[newX,newY].Occupant!="P1"
                && Grid[newX, newY].Occupant != "P2";
        }

        public void CollectGem(Player player)
        {
            if (Grid[player.Position.X, player.Position.Y].Occupant == "G")
            {
                player.GemCount++;

                Gems--;

                Grid[player.Position.X, player.Position.Y].Occupant = "-";
            }
        }
    }
}
