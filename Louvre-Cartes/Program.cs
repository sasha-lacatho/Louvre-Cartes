using LouvreCartes.Data;
using LouvreCartes.Gameplay;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System;
using System.Reflection;

namespace LouvreCartes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameData data = DataLoader.LoadData();
            data.Initialize();

            Game game = new Game(data);


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

            //data.WriteStatistics();

            //Console.ReadLine();


            string directoryPath = @"C:\Dataas";

            string fileName = $"dataLouvre1.csv";
            string filePath = Path.Combine(directoryPath, fileName);
            WriteToCsv(filePath, data.WriteStatsMissionsRates());
            
            fileName = $"dataLouvre2.csv";
            filePath = Path.Combine(directoryPath, fileName);
            WriteToCsv(filePath, data.WriteStatsPairRates());

            fileName = $"dataLouvre3.csv";
            filePath = Path.Combine(directoryPath, fileName);
            WriteToCsv(filePath, data.WriteStatsCardsRates());



            //ReadFromCsv(filePath);
            Console.ReadKey();
        }

        static void WriteToCsv<T>(string filePath, List<T> list)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                using (File.Create(filePath)) { }


                var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false
                };

                using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                using (CsvWriter csvWriter = new CsvWriter(streamWriter, configPersons))
                {
                    csvWriter.WriteRecords(list);
                }

                Console.WriteLine("Data written to CSV successfully.");
            }

            catch (Exception ex)
            {
                throw;
            }

        }
    }


}