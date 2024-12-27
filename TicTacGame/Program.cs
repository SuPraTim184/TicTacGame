using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };

        static char player = 'X';
        static char computer = 'O';
        static char currentTurn = player;

        static void Main(string[] args)
        {
            bool gameRunning = true;

            while (gameRunning)
            {
                Console.Clear();
                DrawBoard();

                if (currentTurn == player)
                {
                    PlayerMove();
                }
                else
                {
                    ComputerMove();
                }

                if (CheckWin())
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine(currentTurn == player ? "You win!" : "Computer wins!");
                    gameRunning = false;
                }
                else if (CheckDraw())
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine("It's a draw!");
                    gameRunning = false;
                }

                currentTurn = currentTurn == player ? computer : player;
            }
        }

        static void DrawBoard()
        {
            Console.WriteLine("\nTic Tac Toe");
            Console.WriteLine("-----------");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($" {board[i, j]} ");
                    if (j < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("---+---+---");
            }
            Console.WriteLine();
        }

        static void PlayerMove()
        {
            int choice;
            bool validMove = false;

            while (!validMove)
            {
                Console.WriteLine("Enter your move (1-9): ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9)
                {
                    validMove = MakeMove(choice, player);
                }

                if (!validMove)
                {
                    Console.WriteLine("Invalid move, try again.");
                }
            }
        }

        static void ComputerMove()
        {
            Random rnd = new Random();
            bool validMove = false;

            while (!validMove)
            {
                int choice = rnd.Next(1, 10);
                validMove = MakeMove(choice, computer);
            }
        }

        static bool MakeMove(int choice, char symbol)
        {
            int row = (choice - 1) / 3;
            int col = (choice - 1) % 3;

            if (board[row, col] != 'X' && board[row, col] != 'O')
            {
                board[row, col] = symbol;
                return true;
            }

            return false;
        }

        static bool CheckWin()
        {
            // Check rows and columns
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2]) ||
                    (board[0, i] == board[1, i] && board[1, i] == board[2, i]))
                {
                    return true;
                }
            }

            // Check diagonals
            if ((board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) ||
                (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]))
            {
                return true;
            }

            return false;
        }

        static bool CheckDraw()
        {
            foreach (char cell in board)
            {
                if (cell != 'X' && cell != 'O') return false;
            }
            return true;
        }
    }
}
