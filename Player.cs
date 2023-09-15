using System;

public class Player
{
    public Player()
    {
        public string PlayerInput1;
        public string PlayerInput2;
        public int PlayerWinsCounter1;
        public int PlayerWinsCounter2;
        public int DeterminedOrder1;
        public int DeterminedOrder2;
        public string Input;
        public int Wins;
        public string Player;
        public int Draws = 0;
        Player Player1 = new Player(PlayerInput1, PlayerWinsCounter1, DeterminedOrder1);
        Player PLayer2 = new Player(PlayerInput1, PlayerWinsCounter1, DeterminedOrder2);

        public Player(string playerName,string playerWins,string playerOrder)
        {
            Input = PlayerName;
            Wins = PlayerWins;
            Player = PlayerOrder;

        }
        public static void CheckUserInput(string firstInput, string secondInput)
        {
            int GameRoundCounter = 0;
            while (GameRoundCounter < 9)
            {

                int Rest = GameRoundCounter % 2;
                if (GameRoundCounter == 0 || Rest == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{firstInput} please type in where you want to place ur X:");
                    int UserInputChoice;
                    bool IsValid = int.TryParse(Console.ReadLine(), out UserInputChoice);

                    int ArrayInput = UserInputChoice - 1;
                    if (IsValid && ArrayInput >= 0 && UserInputChoice <= PlayArea.Length)
                    {
                        if (PlayArea[ArrayInput] != "X" && PlayArea[ArrayInput] != "O")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            PlayArea[ArrayInput] = "X";
                            Console.Clear();
                            DrawPlayfield();
                            bool EvaluationGame = EvaluateGame();
                            if (EvaluationGame)
                            {
                                if (PlayerInput1 == firstInput)
                                {
                                    Console.WriteLine($"{PlayerInput1} wins");
                                    PlayerWinsCounter1 += 1;
                                }
                                else
                                {
                                    Console.WriteLine($"{PlayerInput2} wins");
                                    PlayerWinsCounter2 += 1;
                                }
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
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Please choose a diffrent number");
                            Thread.Sleep(MessagePauseTime);
                            Console.Clear();
                            DrawPlayfield();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Wrong input!");
                        Thread.Sleep(MessagePauseTime);
                        Console.Clear();
                        DrawPlayfield();
                    }
                }
                else if (GameRoundCounter == 0 || Rest == 1)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{secondInput} please type in where you want to place ur 0:");
                    int UserInputChoice;
                    bool IsValid = int.TryParse(Console.ReadLine(), out UserInputChoice);
                    int ArrayInput = UserInputChoice - 1;
                    if (IsValid && ArrayInput >= 0 && UserInputChoice <= PlayArea.Length)
                    {

                        if (PlayArea[ArrayInput] != "X" && PlayArea[ArrayInput] != "O")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            PlayArea[ArrayInput] = "O";
                            Console.Clear();
                            DrawPlayfield();
                            bool EvaluationGame = EvaluateGame();
                            if (EvaluationGame)
                            {
                                if (PlayerInput1 == firstInput)
                                {
                                    Console.WriteLine($"{PlayerInput1} wins");
                                    PlayerWinsCounter1 += 1;
                                }
                                else
                                {
                                    Console.WriteLine($"{PlayerInput2} wins");
                                    PlayerWinsCounter2 += 1;
                                }
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please choose a diffrent number");
                            Thread.Sleep(MessagePauseTime);
                            Console.Clear();
                            DrawPlayfield();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong Input");
                        Thread.Sleep(MessagePauseTime);
                        Console.Clear();
                        DrawPlayfield();
                    }
                }
            }
        }
        public static void ShowGameStats()
        {
            Console.Clear();
            Console.WriteLine($"{PlayerInput1} wins = {PlayerWinsCounter1}");
            Console.WriteLine($"{PlayerInput2} wins = {PlayerWinsCounter2}");
            Console.WriteLine($"Draws = {Draws}");
            Console.ReadKey();
            Environment.Exit(0);
        }
        public static void InitName()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Player 1: ");
            PlayerInput1 = Console.ReadLine();
            Console.Write("Player 2: ");
            PlayerInput2 = Console.ReadLine();
            Console.Clear();

        }
        public static (string, string) RandomizeStartingPlayer(string name1, string name2)
        {
            if (Order == 1)
            {
                return (name1, name2);
            }
            else
            {
                return (name2, name1);
            }
        }
    }
}
