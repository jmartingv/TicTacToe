using System;

namespace TicTacToe
{
    internal class Program
    {
        static string[,] board = new string[3, 3]
        {
                {"1","2","3"},
                {"4","5","6"},
                {"7","8","9"}
        };

        // Round variable to check if the game is over,
        // a game of tic tac toe has a maximum of 9 rounds
        static int round = 0;

        static char playerRestart;
        static void Main(string[] args)
        {
            char currentPlayer;


            

            // Game loop
            while (true)
            {
                // Show the board for each loop
                DisplayBoard();

                // Change the current player
                currentPlayer = 'X';
                Console.WriteLine($"\nRound {++round}:");
                PlayerTurn(currentPlayer);

                // Check if the game is won
                if (IsWon())
                {
                    DisplayBoard();
                    Console.WriteLine($"\nPlayer ({currentPlayer}) wins!");

                    // Ask to restart
                    Console.Write("Press R to play again, or any other key to exit. ");
                    playerRestart = Console.ReadKey().KeyChar;

                    // If player presses R, restart game and continue in loop
                    if (char.ToLower(playerRestart) == 'r')
                    {
                        ResetGame();
                        continue;
                    }
                    else // If any other key is pressed, quit the game
                    {
                        break;
                    }
                }
                
                // Check if the max number of rounds is achieved (i.e. a tie)
                if (round >= 9)
                {
                    DisplayBoard();
                    Console.WriteLine("It's a tie!");
                    Console.Write("Press R to play again, or any other key to exit. ");
                    playerRestart = Console.ReadKey().KeyChar;

                    if (char.ToLower(playerRestart) == 'r')
                    {
                        ResetGame();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                // Refresh the board
                DisplayBoard();


                // Repeat
                currentPlayer = 'O';
                Console.WriteLine($"\nRound {++round}:");
                PlayerTurn(currentPlayer);

                if (IsWon())
                {
                    DisplayBoard();
                    Console.WriteLine($"\nPlayer ({currentPlayer}) wins!");

                    Console.Write("Press R to play again, or any other key to exit. ");
                    playerRestart = Console.ReadKey().KeyChar;

                    if (char.ToLower(playerRestart) == 'r')
                    {
                        ResetGame();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                
                if (round >= 9)
                {
                    DisplayBoard();
                    Console.WriteLine("It's a tie!");

                    Console.Write("Press R to play again, or any other key to exit. ");
                    playerRestart = Console.ReadKey().KeyChar;
                    
                    if(char.ToLower(playerRestart) == 'r')
                    {
                        ResetGame();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            
        }

        static void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine("      |     |      ");
            Console.WriteLine($"   {board[0, 0]}  |  {board[0, 1]}  |  {board[0, 2]}   ");
            Console.WriteLine("      |     |      ");
            Console.WriteLine("------|-----|------");
            Console.WriteLine("      |     |      ");
            Console.WriteLine($"   {board[1, 0]}  |  {board[1, 1]}  |  {board[1, 2]}   ");
            Console.WriteLine("      |     |      ");
            Console.WriteLine("------|-----|------");
            Console.WriteLine("      |     |      ");
            Console.WriteLine($"   {board[2, 0]}  |  {board[2, 1]}  |  {board[2, 2]}   ");
            Console.WriteLine("      |     |      ");
        }

        static bool IsWon()
        {
            // Check horizontal & vertical, are they all equal?
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    return true;

                if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    return true;
            }

            // Same for the diagonals
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return true;

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return true;

            // Default
            return false;
        }

        static void PlayerTurn(char player)
        {
            Console.Write($"Player ({player}): Select a position: ");
            string input = Console.ReadLine();

            // Condition to leave loop until the player selects a valid position
            bool isInputValid = false;

            // Turn loop, the turn won't end until the player selects a valid position
            do
            {
                switch (input)
                {
                    case "1":
                        // If the position is taken by either player, ask again
                        if (board[0, 0] == 'X'.ToString() || board[0, 0] == 'O'.ToString())
                        {
                            Console.Write("\nOops! Position is occupied, try again: ");
                            input = Console.ReadLine();
                            break;
                        }
                        else // if the position is available, then it goes to the player, and the input is considered valid
                        {
                            board[0, 0] = player.ToString();
                            isInputValid = true;
                            break;
                        }
                    case "2":
                        if (board[0, 1] == 'X'.ToString() || board[0, 1] == 'O'.ToString())
                        {
                            Console.Write("\nOops! Position is occupied, try again: ");
                            input = Console.ReadLine();
                            break;
                        }
                        else
                        {
                            board[0, 1] = player.ToString();
                            isInputValid = true;
                            break;
                        }
                    case "3":
                        if (board[0, 2] == 'X'.ToString() || board[0, 2] == 'O'.ToString())
                        {
                            Console.Write("\nOops! Position is occupied, try again: ");
                            input = Console.ReadLine();
                            break;
                        }
                        else
                        {
                            board[0, 2] = player.ToString();
                            isInputValid = true;
                            break;
                        }
                    case "4":
                        if (board[1, 0] == 'X'.ToString() || board[1, 0] == 'O'.ToString())
                        {
                            Console.Write("\nOops! Position is occupied, try again: ");
                            input = Console.ReadLine();
                            break;
                        }
                        else
                        {
                            board[1, 0] = player.ToString();
                            isInputValid = true;
                            break;
                        }
                    case "5":
                        if (board[1, 1] == 'X'.ToString() || board[1, 1] == 'O'.ToString())
                        {
                            Console.Write("\nOops! Position is occupied, try again: ");
                            input = Console.ReadLine();
                            break;
                        }
                        else
                        {
                            board[1, 1] = player.ToString();
                            isInputValid = true;
                            break;
                        }
                    case "6":
                        if (board[1, 2] == 'X'.ToString() || board[1, 2] == 'O'.ToString())
                        {
                            Console.Write("\nOops! Position is occupied, try again: ");
                            input = Console.ReadLine();
                            break;
                        }
                        else
                        {
                            board[1, 2] = player.ToString();
                            isInputValid = true;
                            break;
                        }
                    case "7":
                        if (board[2, 0] == 'X'.ToString() || board[2, 0] == 'O'.ToString())
                        {
                            Console.Write("\nOops! Position is occupied, try again: ");
                            input = Console.ReadLine();
                            break;
                        }
                        else
                        {
                            board[2, 0] = player.ToString();
                            isInputValid = true;
                            break;
                        }
                    case "8":
                        if (board[2, 1] == 'X'.ToString() || board[2, 1] == 'O'.ToString())
                        {
                            Console.Write("\nOops! Position is occupied, try again: ");
                            input = Console.ReadLine();
                            break;
                        }
                        else
                        {
                            board[2, 1] = player.ToString();
                            isInputValid = true;
                            break;
                        }
                    case "9":
                        if (board[2, 2] == 'X'.ToString() || board[2, 2] == 'O'.ToString())
                        {
                            Console.Write("\nOops! Position is occupied, try again: ");
                            input = Console.ReadLine();
                            break;
                        }
                        else
                        {
                            board[2, 2] = player.ToString();
                            isInputValid = true;
                            break;
                        }
                    default:
                        // If the player enters anything else, ask again
                        Console.Write("Oops, that's not a valid position! Try again: ");
                        input = Console.ReadLine();
                        break;
                }
            } while (!isInputValid);
        }

        static void ResetGame()
        {
            board = new string[3, 3]
            {
                {"1","2","3"},
                {"4","5","6"},
                {"7","8","9"}
            };

            round = 0;
        }
    }
}
