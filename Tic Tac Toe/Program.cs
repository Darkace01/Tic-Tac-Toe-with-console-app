using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
       static String [] board = new String[9];
        static String playsAgain = "Y";
        static int counter = 0;

       static void initializeVariable()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = i.ToString();
            }
        }

        static void Main(string[] args)
        {            
            introduction();
            while (playsAgain.Equals ("Y"))
            {
                initializeVariable();
                while (hasWon() == false && counter < 9)
                {
                    askData("X");
                    if (hasWon() == true)
                        break;
                    askData("O");
                }
                if (hasWon() == true)
                    playAgainMsg("Congratulation! You won!");
                else
                    playAgainMsg("This was a tie game!");
            }
            goodBye();
        }

        static void goodBye()
        {
            Console.WriteLine("Thanks for playing");
            Console.ReadLine();
        }

        static void askData(String player)
        {
            Console.Clear();
            Console.WriteLine("Player: " + player);
            int selection;
            while (true)
            {
                Console.WriteLine("Enter your selection");
                drawBoard();

                selection = Convert.ToInt32(Console.ReadLine());
                if (selection < 0 || selection > 9 || (board[selection].Equals("X") || board[selection].Equals("O")))
                    Console.WriteLine("invalid selection!");
                else
                    break;
            }
            board[selection] = player;
        }

        static void drawBoard()
        {
            for (int i =0; i < 9; i+=3)
                Console.WriteLine(board[i] + "|" + board[i + 1] + "|" + board[i + 2]);
        }

        static void playAgainMsg(string message)
        {
            Console.WriteLine("Do you want to play again (y / n)");
            if (Console.ReadLine().Equals("Y"))
                playsAgain.Equals("Y");
            else
                playsAgain.Equals("N");
        }

        static Boolean hasWon()
        {
            for (int i = 0; i < 7; i += 3)
            {
                if (board[i].Equals(board[i + 1]) && board[i + 1].Equals(board[1 + 2]))
                {
                    return true;
                }
            }
            if (board[0].Equals(board[3]) && board[3].Equals(board[6]))
                return true;
            if (board[1].Equals(board[4]) && board[4].Equals(board[7]))
                return true;
            if (board[2].Equals(board[5]) && board[5].Equals(board[8]))
                return true;
            if (board[2].Equals(board[4]) && board[4].Equals(board[6]))
                return true;
            if (board[0].Equals(board[4]) && board[4].Equals(board[8]))
                return true;
            if (board[0].Equals(board[1]) && board[1].Equals(board[2]))
                return true;
            if (board[3].Equals(board[4]) && board[4].Equals(board[5]))
                return true;
            if (board[6].Equals(board[7]) && board[7].Equals(board[8]))
                return true;
            return false;
        }

        static void introduction()
        {
            Console.Title = ("Tic Tac Toes Verion 1.0");
            Console.WriteLine("Welcome To Tic Tac Toe");
            Console.WriteLine("Press any Key to Continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
