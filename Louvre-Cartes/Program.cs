using LouvreCartes.Data;
using LouvreCartes.Gameplay;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace LouvreCartes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameData data = DataLoader.LoadData();
            data.Initialize();

            //data.TestAll();

            Game game = new Game(data);

            //Console.WriteLine("Extracted data :");
            //Console.WriteLine(data);

            int start = Environment.TickCount;
            int oneMinute = Environment.TickCount + (60 * 1000);

            int gameCount = 0;
            // play games for one minute
            while(Environment.TickCount < oneMinute)
            {
                game.InitializeGame();
                game.PlayGame();
                game.EndGame();

                gameCount++;
                Console.Write($"\r{gameCount}x games : {(Environment.TickCount - start) / 1000f}s");
            }
            Console.WriteLine($"\rDONE : {gameCount}x games played in 60s                                          ");

            data.WriteStatistics();

            Console.ReadLine();
        }
    }
}