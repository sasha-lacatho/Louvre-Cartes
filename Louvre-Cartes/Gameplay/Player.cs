using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LouvreCartes.Data;
using LouvreCartes.Utility;

namespace LouvreCartes.Gameplay
{
    public class Player
    {
        public int ID;
        public int Gold;
        public int SavedGold;
        public Mission[] Missions = new Mission[2];
        public List<Card> Cards = new List<Card>();

        public Player(int id, int gold, Mission[] missions) 
        {
            ID = id;

            Gold = gold;

            Missions = missions;
        }

        public bool GoldWinner;
        public int TotalPrestige;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Player : {ID} : g.{Gold}");
            sb.AppendLine("Missions :");
            foreach (Mission mission in Missions)
            {
                sb.Append(" - ");
                sb.AppendLine(mission.Text);
            }
            sb.AppendLine("Cards :");
            foreach (Card card in Cards)
            {
                sb.Append(" - ");
                sb.AppendLine(card.Name);
            }

            return sb.ToString();
        }

        public int Bid(Card card)
        {
            Random random = new Random();
            int minBid = IsImportantForMissions(card) ? 20 + card.Prestige * 10 : -10 + card.Prestige * 10;
            int maxBid = IsImportantForMissions(card) ? 70 + card.Prestige * 10 : 40 + card.Prestige * 10;
            return random.Next(minBid, maxBid + 1);
        }

        public bool IsImportantForMissions(Card card)
        {
            Random random = new Random();
            return random.Next(2) == 0; // Random simulation
        }


    }
}
