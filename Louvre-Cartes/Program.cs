using LouvreCartes.Data;
using LouvreCartes.Gameplay;
using LouvreCartes.Export;

namespace LouvreCartes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameData data = DataLoader.LoadData();
            data.Initialize();

            Game game = new Game(data);

            #region Simulate 60sec of Games
            int start = Environment.TickCount;
            int oneMinute = Environment.TickCount + (60 * 1000);

            int gameCount = 0;
            // play games for one minute
            while (Environment.TickCount < oneMinute)
            {
                game.InitializeGame();
                game.PlayGame();
                game.EndGame();

                gameCount++;
                Console.Write($"\r{gameCount}x games : {(Environment.TickCount - start) / 1000f}s");
            }
            Console.WriteLine($"\rDONE : {gameCount}x games played in 60s                                          ");
            #endregion

            #region Export To CSV
            ExportToCSV exportCSV = new ExportToCSV();
            exportCSV.WriteAllToCSV(data);
            #endregion


            Console.ReadKey();
        }

    }
}