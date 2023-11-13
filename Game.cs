using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Game
    {
        public Board Board { get; }
        public Player Player1 { get; }
        public Player Player2 { get; }
        public Player CurrentTurn { get; set; }
        public int TotalTurns { get; set; }

        public Game()
        {
            Board = new Board();
            Player1 = new Player("P1", new Position(0, 0));
            Player2 = new Player("P2", new Position(5, 5));
            CurrentTurn = Player1;
            TotalTurns = 0;
        }

        public void Begin()
        {                        

            while (!IsGameOver())
            {

                Console.Clear();
                //Invoking the show game info method
                ShowGameInfo();
               
                //Displaying the board
                Board.Display();

                Console.WriteLine($"\nIt is {CurrentTurn.Name}'s turn. \nPlease enter U (UP), D (Down), L (Left), or R (Right): \n");

                char direction = char.ToUpper(Console.ReadKey().KeyChar);



                if (Board.IsValidMove(CurrentTurn, direction))
                {
                    Board.Grid[CurrentTurn.Position.X, CurrentTurn.Position.Y].Occupant = "_";

                    CurrentTurn.Move(direction);

                    Board.CollectGem(CurrentTurn);

                    Board.Grid[CurrentTurn.Position.X, CurrentTurn.Position.Y].Occupant = CurrentTurn.Name;
                    

                    TotalTurns++;

                    Board.Display();

                    SwitchTurn();
                }
                else
                {
                    Console.WriteLine("That Move is invalid! Try again.");
                }
            }

            Console.Clear();
            ShowGameInfo();
            Board.Display();
            Console.WriteLine("-----------------------------------------------------\n");
            AnnounceWinner();
        }

        public void SwitchTurn()
        {
            //using ternary expression  to simplify the if else condition
            CurrentTurn = (CurrentTurn == Player1) ? Player2 : Player1;
        }

        public bool IsGameOver()
        {            
            //The game ends when all the moves are exausted or when all the gems have been collected
            return TotalTurns >= 30 || Board.Gems==0;
        }

        public void AnnounceWinner()
        {
            if (Player1.GemCount > Player2.GemCount)
            {
                Console.WriteLine($"\nPlayer 1 (P1) wins with a total count of {Player1.GemCount} gems.");
                Console.WriteLine("Thank you for playing");
            }
            else if (Player2.GemCount > Player1.GemCount)
            {
                Console.WriteLine($"\nPlayer 2 (P2) wins with a total count of {Player2.GemCount} gems.");
                Console.WriteLine("Thank you for playing");
            }
            else
            {
                Console.WriteLine("\n It's a tie!");
                Console.WriteLine("Thank you for playing");
            }
        }

        public void ShowGameInfo()
        {
            Console.WriteLine("---------------------GEM HUNTERS---------------------\n");
            Console.WriteLine("             AUTHOR:  LIONEL IRAKOZE                 \n");
            Console.WriteLine("             ID:      8940487                        \n");
            Console.WriteLine("         COURSE: High Software Quality Programming   \n");
            Console.WriteLine("-----------------------------------------------------\n");
        }

    }
}
