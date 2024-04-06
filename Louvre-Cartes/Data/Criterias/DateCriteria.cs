using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class DateCriteria : MissionCriteria
    {
        public override int CalculatePrestige(Mission mission, List<Card> cards)
        {
            int prestige = 0;

            foreach (Card card in cards)
            {
                bool inferior = mission.X is Int64 value && value == 0;
                if( inferior ? (card.Date <= 0) : (card.Date >= 0))
                {
                    prestige += mission.Prestige;
                    if (mission.Repeat == 0) break;
                }
            }

            return prestige;
        }

        protected override bool CheckCriteria(Mission mission, int count, Card card)
        {
            bool inferior = mission.X is Int64 value && value == 0;
            return inferior ? (card.Date <= 0) : (card.Date >= 0);
        }
    }
}
