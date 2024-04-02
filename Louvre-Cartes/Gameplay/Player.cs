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
            int bid = 0;

            if(IsImportantForMissions(card))
            {
                bid = random.Next(20, 70) + card.Prestige * 10;
            }
            else
            {
                bid = random.Next(-10, 40) + card.Prestige * 10;
            }

            Console.WriteLine($"Is important for missions ? : {IsImportantForMissions(card)}");

            return bid;
        }

        public bool IsImportantForMissions(Card card)
        {
            foreach (Mission mission in Missions)
            {
                if(mission.TypeMission.Criteria.CheckIsImportant(card.Prestige, card.Type, card.Location, card.Date, card.Height))
                    return true;
            }

            return false;
        }
    }
}
