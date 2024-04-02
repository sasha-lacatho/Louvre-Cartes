using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class Player
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();
        public int TotalPrestige { get; set; }
        //{
        //    get
        //    {
        //        int total = 0;
        //        foreach (Card card in Cards)
        //        {
        //            total += card.Prestige;
        //        }
        //        if (GoldWinner) // If the player is the winner of gold, add 2 points of prestige
        //        {
        //            total += 2;
        //        }
        //        return total;
        //    }
        //}
        public bool GoldWinner { get; set; }

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
