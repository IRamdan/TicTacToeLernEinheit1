using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLernEinheit1.Models
{
    public class TicTacToeGame
    {

        string Greeting = "TIC TAC TOE or CONNECT FOUR\n\n\n\tWelcome\n\n\nPlease press enter to continue";
        int ColorChangeSpeed = 140;
        int ColorChange = 0;
        static string[] PlayArea = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static string[] PlayAreaCopy = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static bool FirstHorizontalWin;
        static bool SecondHorizontalWin;
        static bool ThirdHorizontalWin;
        static bool FirstVerticalWin;
        static bool SecondVerticalWin;
        static bool ThirdVerticalWin;
        static bool FirstDiagonalWin;
        static bool SecondDiagonalWin;
        static int MessagePauseTime = 800;

        static Player Player1 = new Player(PlayerInput1, PlayerWins1);
        static Player Player2 = new Player(PlayerInput2, PlayerWins2);

        static string PlayerInput1;
        static string PlayerInput2;
        static int PlayerWins1 = 0;
        static int PlayerWins2 = 0;
        static int Draws = 0;

        public void WelcomeScreen()
        {

            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                for (int i = 0; i < Greeting.Length; i++)
                {
                    if ((i + ColorChange) % 3 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Greeting[i]);
                    }
                    else if ((i + ColorChange) % 3 == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(Greeting[i]);
                    }
                    else if ((i + ColorChange) % 3 == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Greeting[i]);
                    }
                }
                ColorChange++;
                System.Threading.Thread.Sleep(ColorChangeSpeed);
                while (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        return;
                }
            } while (true);
        }
        public void DrawPlayfield()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($" {PlayArea[0]} | {PlayArea[1]} | {PlayArea[2]} \n---+---+---\n {PlayArea[3]} | {PlayArea[4]} | {PlayArea[5]} \n---+---+---\n {PlayArea[6]} | {PlayArea[7]} | {PlayArea[8]} ");
        }
        public void InitName()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Player 1: ");
            Player1.Name = Console.ReadLine();
            Console.Write("Player 2: ");
            Player2.Name = Console.ReadLine();
            Console.Clear();
        }
        public (string, string) RandomizeStartingPlayer(string name1, string name2)

        {
            Random OrderMaximum = new Random();
            int Order = OrderMaximum.Next(0, 2);
            if (Order == 1)
            {
                return (name1, name2);
            }
            else
            {
                return (name2, name1);
            }
        }
        public void ShowGameStats()
        {
            Console.Clear();
            Console.WriteLine($"{Player1.Name} wins = {Player1.Wins}");
            Console.WriteLine($"{Player2.Name} wins = {Player2.Wins}");
            Console.WriteLine($"Draws = {Draws}");
            Console.ReadKey();
            Environment.Exit(0);
        }
        public bool EvaluateGame()
        {
            FirstHorizontalWin = (PlayArea[0] == PlayArea[1] && PlayArea[1] == PlayArea[2]);
            SecondHorizontalWin = (PlayArea[3] == PlayArea[4] && PlayArea[4] == PlayArea[5]);
            ThirdHorizontalWin = (PlayArea[6] == PlayArea[7] && PlayArea[7] == PlayArea[8]);
            FirstVerticalWin = (PlayArea[0] == PlayArea[3] && PlayArea[3] == PlayArea[6]);
            SecondVerticalWin = (PlayArea[1] == PlayArea[4] && PlayArea[4] == PlayArea[7]);
            ThirdVerticalWin = (PlayArea[2] == PlayArea[5] && PlayArea[5] == PlayArea[8]);
            FirstDiagonalWin = (PlayArea[0] == PlayArea[4] && PlayArea[4] == PlayArea[8]);
            SecondDiagonalWin = (PlayArea[6] == PlayArea[4] && PlayArea[4] == PlayArea[2]);

            if (FirstHorizontalWin || SecondHorizontalWin || ThirdHorizontalWin || FirstVerticalWin || SecondVerticalWin || ThirdVerticalWin || FirstDiagonalWin || SecondDiagonalWin)
            {
                return (true);
            }

            else
            {
                return (false);
            }

        }
        public void InitGame()
        {
            (Player1.Name, Player2.Name) = RandomizeStartingPlayer(Player1.Name, Player2.Name);
            DrawPlayfield();
            CheckUserInput();
        }
        public void InitReplay()
        {
            string Response;
            Console.WriteLine("Please press any key to continue");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Do you want to play again? (Y)es / (N)o");
            Response = Console.ReadLine().ToLower();
            if (Response == "y")
            {
                Array.Copy(PlayAreaCopy, PlayArea, PlayArea.Length);
                Console.Clear();
                InitGame();
            }
            else if (Response == "n")
            {
                ShowGameStats();
            }
            else
            {
                Console.WriteLine("Falscher Input");
                Console.ReadKey();
                Console.Clear();
                InitReplay();
            }
        }
        //TODO Winscounter funktioniert nicht mehr richtig 
        public void CheckUserInput()
        {
            int GameRoundCounter = 0;
            while (GameRoundCounter < 9)
            {
                int Rest = GameRoundCounter % 2;
                Player CurrentPlayer = Rest == 0 ? Player1 : Player2;
                ConsoleColor CurrentColor = Rest == 0 ? ConsoleColor.Blue : ConsoleColor.Red;
                string CurrentSign = Rest == 0 ? "X" : "O";
                Console.ForegroundColor = CurrentColor;
                Console.WriteLine($"{CurrentPlayer.Name} please type in where you want to place ur {CurrentSign}:");
                int UserInputChoice;
                bool IsValid = int.TryParse(Console.ReadLine(), out UserInputChoice);
                int ArrayInput = UserInputChoice - 1;
                if (IsValid && ArrayInput >= 0 && UserInputChoice <= PlayArea.Length)
                {
                    if (PlayArea[ArrayInput] != "X" && PlayArea[ArrayInput] != "O")
                    {
                        Console.ForegroundColor = CurrentColor;
                        PlayArea[ArrayInput] = CurrentSign;
                        Console.Clear();
                        DrawPlayfield();
                        bool EvaluationGame = EvaluateGame();
                        if (EvaluationGame)
                        {
                            Console.WriteLine($"{CurrentPlayer.Name} wins");
                            CurrentPlayer.Wins += 1;
                            InitReplay();
                        }
                        else if (GameRoundCounter == 8)
                        {
                            Console.WriteLine("Oh a Draw");
                            Draws += 1;
                            InitReplay();
                        }
                        GameRoundCounter++;
                    }
                    else
                    {
                        Console.ForegroundColor = CurrentColor;
                        Console.WriteLine("Please choose a diffrent number");
                        Thread.Sleep(MessagePauseTime);
                        Console.Clear();
                        DrawPlayfield();
                    }
                }
                else
                {
                    Console.ForegroundColor = CurrentColor;
                    Console.WriteLine("Wrong input!");
                    Thread.Sleep(MessagePauseTime);
                    Console.Clear();
                    DrawPlayfield();
                }
            }
        }
    }
}
