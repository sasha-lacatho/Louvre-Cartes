using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouvreCartes.Data;

namespace LouvreCartes.Export
{
    public class ExportToCSV
    {
        public void WriteAllToCSV(GameData data)
        {
            string directoryPath = @"C:\Dataas";

            // Missions Rates
            string fileName = $"DataLouvre - MissionRates.csv";
            string filePath = Path.Combine(directoryPath, fileName);
            WriteToCsv(filePath, data.WriteStatsMissionsRates());

            // Pair Rates
            fileName = $"DataLouvre - PairWinRates.csv";
            filePath = Path.Combine(directoryPath, fileName);
            WriteToCsv(filePath, data.WriteStatsPairRates());

            // Cards Rates
            fileName = $"DataLouvre - CardsWinRates.csv";
            filePath = Path.Combine(directoryPath, fileName);
            WriteToCsv(filePath, data.WriteStatsCardsRates());
        }

        void WriteToCsv<T>(string filePath, List<T> list)
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
