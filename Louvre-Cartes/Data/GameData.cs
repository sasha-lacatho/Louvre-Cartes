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
        public Card[] Cartes;


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("GameData :");

            sb.AppendLine("\n - Missions -\n");
            foreach (Mission item in Missions) { sb.AppendLine(item.ToString()); }

            sb.AppendLine("\n - Types -\n");
            foreach (MissionType item in Types) sb.AppendLine(item.ToString());

            sb.AppendLine("\n - Cards -\n");
            foreach (Card item in Cartes) sb.AppendLine(item.ToString());

            return sb.ToString();
        }
    }
}
