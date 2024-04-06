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
            foreach (Mission mission in Missions)
            {
                mission.Criteria = Types[mission.Type].Criteria;
            }
        }
        public void TestAll()
        {
            foreach (Card card in Cards)
            {
                Console.WriteLine(card.ToString() + '\n');

                foreach(Mission mission in Missions)
                {
                    Console.WriteLine($" - [{mission.Criteria.IsImportant(mission, new Card[0], card)}] ({mission.Criteria.GetType().Name}) {mission.Text}");
                }

                Console.WriteLine("\n - - - - - - - - - - - \n");
            }
        }
    }
}
