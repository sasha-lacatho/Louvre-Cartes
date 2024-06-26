﻿using System;
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

        public const int IMPORTANT_MINBID = 20;
        public const int IMPORTANT_MAXBID = 70;
        public const int NOT_IMPORTANT_MINBID = -10;
        public const int NOT_IMPORTANT_MAXBID = 40;


        public Player(int id, int gold, Mission[] missions) 
        {
            ID = id;

            Gold = gold;

            Missions = missions;
        }

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
            if(Gold == 0) return 0;

            Random random = new Random();
            int bid = 0;

            //Console.Write($"{card} is important for : ");
            //Console.WriteLine($"*** Is Important : {IsImportantForMissions(card)}");
            if (IsImportantForMissions(card))
            {
                bid = random.Next(IMPORTANT_MINBID, IMPORTANT_MAXBID) + card.Prestige * 10;
            }
            else
            {
                bid = random.Next(NOT_IMPORTANT_MINBID, NOT_IMPORTANT_MAXBID) + card.Prestige * 10;
            }

            // If too much bid, tapis
            if (bid > Gold)
                bid = Gold;

            return bid;
        }

        public bool IsImportantForMissions(Card card)
        {
            foreach (Mission mission in Missions)
            {
                bool val = mission.Criteria.IsImportant(mission, Cards, card);
                //Console.WriteLine($"{val} : {mission}");
                if (val)
                    return true;
            }

            return false;
        }
    }
}
