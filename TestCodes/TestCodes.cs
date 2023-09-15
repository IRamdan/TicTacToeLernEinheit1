internal class Program
{
    private static void Main(string[] args)
    {
        //public void ShowMenu()
        //{
        //    bool PlayerHasChoosen = false;
        //    while (!PlayerHasChoosen)
        //    {
        //        Console.WriteLine("Bitte wählen Sie eine Option aus dem Menü:");
        //        Console.WriteLine("1. Voreingestellte Spiele");
        //        Console.WriteLine("2. Benutzerdefinierte Spiele");
        //        Console.WriteLine("3. Spielstatistiken");
        //        Console.WriteLine("4. Einstellungen");
        //        Console.WriteLine("5. Spiel beenden");

        //        string UserInput = Console.ReadLine();
        //        switch (UserInput)
        //        {
        //            case "1":
        //                InitGame();
        //                InitPlayer();
        //                PlayerHasChoosen = true;
        //                break;
        //            case "2":
        //                CustomGame();
        //                PlayerHasChoosen = true;
        //                break;
        //            case "3":
        //                ShowStatistics(History, Players);
        //                PlayerHasChoosen = true;
        //                break;
        //            case "4":
        //                Settings();
        //                PlayerHasChoosen = true;
        //                break;
        //            case "5":
        //                Environment.Exit(1);
        //                break;
        //            default:
        //                Console.WriteLine("Ungültige Eingabe, bitte versuchen Sie es erneut.");
        //                break;
        //        }
        //    }
        //}
        //public void CustomGame()
        //{
        //    Console.WriteLine("Wähle deinen Spieltypen aus\n1.TicTacToe");
        //    ChooseGame();
        //    bool PlayerHasChoosen = false;
        //    while (!PlayerHasChoosen)
        //    {
        //        Console.WriteLine($"1.Reihen: {CurrentMatch.GameFieldRows}");
        //        Console.WriteLine($"2.Zeilen: {CurrentMatch.GameFieldCols}");
        //        Console.WriteLine($"3.Notwendige Anzahl an gleichen Zeichen zum Gewinnen: {CurrentMatch.WinCondition}");
        //        Console.WriteLine($"4.Spieleranzahl: {Players.Count}");

        //        string UserInput = Console.ReadLine();
        //        switch (UserInput)
        //        {
        //            case "1":
        //                CurrentMatch.GameFieldRows = ChangeValue();
        //                PlayerHasChoosen = true;
        //                break;
        //            case "2":
        //                CurrentMatch.GameFieldCols = ChangeValue();
        //                PlayerHasChoosen = true;
        //                break;
        //            case "3":
        //                CurrentMatch.WinCondition = ChangeValue();
        //                PlayerHasChoosen = true;
        //                break;
        //            case "4":
        //                NumberOfPlayers = ChangeValue();
        //                PlayerHasChoosen = true;
        //                break;
        //            default:
        //                Console.WriteLine("Ungültige Eingabe, bitte versuchen Sie es erneut.");
        //                break;
        //        }
        //    }
        //}
        //public int ChangeValue()
        //{
        //    int UserChoice;
        //    bool IsUserInputAnInt = int.TryParse(Console.ReadLine(), out UserChoice);
        //    do
        //    {
        //        return UserChoice;
        //    }
        //    while (IsUserInputAnInt);

        //}
        //public void Settings()
        //{

        //}
    }
}