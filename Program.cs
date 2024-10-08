// Test Connection

/*
PROJECT: Tic Tac Toe
CREATED BY; Andrew Stamm

DESCRIPTION: This program runs a simulation 
of the game Tic Tac Toe in the terminal

*/
using System;
using System.Collections.Generic;

namespace W02_TicTacToe
{
    class Program
    {
        static void Main()
        {   
            //Intro
            Console.WriteLine("\nTIC - TAC - TOE\n\nGet three in a row to win.");

            //Variables
            List<string> board = CreateBoard();
            List<string> players = new List<string>();
            players.Add("X");
            players.Add("O");
            string response = "";

            //Program
            while (true) {
                foreach (string player in players) {
                    DisplayBoard(board);
                    while (true) {
                        Console.WriteLine($"{player}'s Turn\n  - Enter a number to place an {player} on the board.\n  - Enter \"exit\" to exit game");
                        response = Console.ReadLine();
                        if (response.ToLower() == "exit") {
                            goto End;
                        }
                        if (isValidMove(board, response)) {
                            break;
                        }
                        Console.WriteLine("Invalid Response. Choose a number on the board.");
                    }
                    board[int.Parse(response) - 1] = $"{player}";
                    if (isWinning(board)) {
                        DisplayBoard(board);
                        Console.WriteLine($"\n{player} WINS!!!\n");
                        goto End;
                    }
                    if (isCat(board)) {
                        DisplayBoard(board);
                        PrintCat();
                        Console.WriteLine($"\nYou have a Cat. Be careful. It scratches!\n");
                        goto End;
                    }
                }
            }
            // End Message
            End:
                Console.WriteLine("\nThank you for playing! ;)\n"); 
        }

        static List<string> CreateBoard()
        { /* Creates a new board
        none --> none
        */
            List<string> board = new List<string>();
            for (int i = 0; i < 9; i++) {
                board.Add($"{i + 1}");
            }
            return board;
        }

        static void DisplayBoard(List<string> board)
        { /* Given a list of nine strings, this function displays a board
        List<string> board --> none
        */
            Console.WriteLine($"\n{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("- + - + -");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("- + - + -");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}\n");
        }

        static bool isValidMove(List<string> board, string response)
        { /* Given a board and a respone, this function says whether the response is a valid move.
        List<string> board, string response --> bool
        */
            if (board[int.Parse(response) - 1] == response)
            {
                return true;
            }
            return false;
        }

        static bool isWinning(List<string> board)
        { /* Given a board, this function determines whether the board contains a winning row, column, or Diagnal.
        List<string> board --> bool
        */
            for (int i = 0; i < 3; i++) {
                //Check columns and Check Rows
                if (board[i] == board[i + 3] && board[i + 3] == board[i + 6] || board[i * 3] == board[i * 3 + 1] && board[i * 3 + 1] == board[i * 3 + 2]) {
                    return true;
                }
            }
            //Check diagnals      
            if (board[0] == board[4] && board[4] == board[8] || board[2] == board[4] && board[4] == board[6]) {
                return true;
            }
            return false;
        }

        static bool isCat(List<string> board)
        { /* Given a board, this function determines whether or not there is a tie, or a "cat"
        List<string> board --> bool
        */
            for (int i = 0; i < 9; i++) {
                if (board[i] == $"{i + 1}") {
                    return false;
                }
            }
            return true;
        }
        static void PrintCat()
        { /* This function prints an ascii cat to the console.
        none --> none
        */
            Console.WriteLine("\n|\\___/|");
            Console.WriteLine("| * * |");
            Console.WriteLine("|  *  |");
            Console.WriteLine("| ~~~ |");
            Console.WriteLine("\\     /");
            Console.WriteLine(" |   |");
            Console.WriteLine("~MEOW!~\n");
        }
    }
}