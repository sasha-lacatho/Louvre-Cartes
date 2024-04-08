using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LouvreCartes.Data;
using System.Diagnostics;

namespace LouvreCartes.Export
{
    public class ExportToCSV
    {
        public void WriteAllToCSV(GameData data)
        {
            string directoryPath = Directory.GetCurrentDirectory();

            // Missions Rates
            string fileName = $"DataLouvre - MissionRates.csv";
            string filePath = Path.Combine(directoryPath, fileName);
            WriteToCsv(filePath, data.WriteStatsMissionsRates());
            Process.Start("notepad.exe", filePath);

            // Pair Rates
            fileName = $"DataLouvre - PairWinRates.csv";
            filePath = Path.Combine(directoryPath, fileName);
            WriteToCsv(filePath, data.WriteStatsPairRates());
            Process.Start("notepad.exe", filePath);

            // Cards Rates
            fileName = $"DataLouvre - CardsWinRates.csv";
            filePath = Path.Combine(directoryPath, fileName);
            WriteToCsv(filePath, data.WriteStatsCardsRates());
            Process.Start("notepad.exe", filePath);
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
