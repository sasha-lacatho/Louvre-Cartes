using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class GameData
    {
        public Mission[] Missions;
        public MissionType[] Types;
        public Card[] Cards;

        public WinRate[,] PairWinRate;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("GameData :");

            sb.AppendLine("\n - Missions -\n");
            foreach (Mission item in Missions) { sb.AppendLine(item.ToString()); }

            sb.AppendLine("\n - Types -\n");
            foreach (MissionType item in Types) sb.AppendLine(item.ToString());

            sb.AppendLine("\n - Cards -\n");
            foreach (Card item in Cards) sb.AppendLine(item.ToString());

            return sb.ToString();
        }

        public void Initialize()
        {
            // ----- Need to Init mission.Criteria because it's null -----
            int id = 0;
            foreach (Mission mission in Missions)
            {
                mission.Criteria = Types[mission.Type].Criteria;
                mission.ID = id++;
            }

            // ----- Need to Init card.WinRate -----
            foreach (Card card in Cards)
            {
                card.MissionWinRate = new WinRate[Missions.Length];
            }

            PairWinRate = new WinRate[Missions.Length, Missions.Length];
        }
        public void TestAll()
        {
            foreach (Card card in Cards)
            {
                Console.WriteLine(card.ToString() + '\n');

                foreach (Mission mission in Missions)
                {
                    Console.WriteLine($" - [{mission.Criteria.IsImportant(mission, new Card[0], card)}] ({mission.Criteria.GetType().Name}) {mission.Text}");
                }

                Console.WriteLine("\n - - - - - - - - - - - \n");
            }
        }

        public void WriteStatistics()
        {
            Console.WriteLine("\n - - Logging WinRates - - \n");
            Console.WriteLine("\n - Missions - \n");

            #region Mission WinRates
            WriteStatsMissionsRates();
            #endregion

            Console.WriteLine("\n - Pairs - \n");

            #region Pair WinRates
            WriteStatsPairRates();
            #endregion

            Console.WriteLine("\n - Cards - \n");

            #region Cards rates
            WriteStatsCardsRates();
            #endregion
        }

        public List<DataWinRatesToCSV> WriteStatsMissionsRates()
        {
            List<DataWinRatesToCSV> firstData = new List<DataWinRatesToCSV>();

            firstData.Add(new DataWinRatesToCSV { Info1 = "WinRate Ratio", Info2 = "Missions"});
            foreach (Mission mission in Missions.ToList().OrderBy(item => item.WinRate.Ratio))
            {
                Console.WriteLine($" - {mission.WinRate.RatioText} {mission.Text}");
                firstData.Add(new DataWinRatesToCSV { Info1 = mission.WinRate.RatioText, Info2 = mission.Text });
            }

            return firstData;
        }

        public List<DataWinRatesToCSV> WriteStatsPairRates()
        {
            List<DataWinRatesToCSV> secondData = new List<DataWinRatesToCSV>();

            //find and Order rates
            secondData.Add(new DataWinRatesToCSV { Info1 = "WinRate Ratio", Info2 = "Missions 1", Info3 = "Missions 2" });
            List<KeyValuePair<(Mission, Mission), WinRate>> pairRates = new List<KeyValuePair<(Mission, Mission), WinRate>>();
            for (int i = 0; i < Missions.Length; i++)
            {
                for (int n = i + 1; n < Missions.Length; n++)
                {
                    pairRates.Add(new KeyValuePair<(Mission, Mission), WinRate>((Missions[i], Missions[n]), PairWinRate[i, n]));
                }
            }

            //print rates
            foreach (KeyValuePair<(Mission, Mission), WinRate> item in pairRates.OrderBy(item => item.Value.Ratio))
            {
                Console.WriteLine($" - {item.Value.RatioText} {item.Key.Item1.Text} /  {item.Key.Item2.Text}");
                secondData.Add(new DataWinRatesToCSV { Info1 = item.Value.RatioText, Info2 = item.Key.Item1.Text, Info3 = item.Key.Item2.Text });
            }

            return secondData;
        }

        public List<DataWinRatesToCSV> WriteStatsCardsRates()
        {
            List<DataWinRatesToCSV> thirdData = new List<DataWinRatesToCSV>();

            thirdData.Add(new DataWinRatesToCSV { Info1 = "Card Name", Info2 = "WinRate Ratio", Info3 = "Missions" });
            KeyValuePair<Mission, WinRate>[] cardRates = new KeyValuePair<Mission, WinRate>[Missions.Length];
            foreach (Card card in Cards)
            {
                for (int n = 0; n < card.MissionWinRate.Length; n++)
                {
                    cardRates[n] = new KeyValuePair<Mission, WinRate>(Missions[n], card.MissionWinRate[n]);
                }

                //print rates
                Console.WriteLine($" - {card.Name} :");
                thirdData.Add(new DataWinRatesToCSV { Info1 = card.Name });
                foreach (KeyValuePair<Mission, WinRate> item in cardRates.OrderBy(item => item.Value.Ratio))
                {
                    Console.WriteLine($"   {item.Value.RatioText} {item.Key.Text}");
                    thirdData.Add(new DataWinRatesToCSV { Info2 = item.Value.RatioText, Info3 = item.Key.Text });
                }

                Console.WriteLine();
            }

            return thirdData;
        }
    }


    public class DataWinRatesToCSV
    {
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string Info4 { get; set; }
    }
}
