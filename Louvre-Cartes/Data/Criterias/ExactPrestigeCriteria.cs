using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class ExactPrestigeCriteria : MissionCriteria
    {
        public override int CalculatePrestige(Mission mission, List<Card> cards)
        {
            int prestige = 0;

            if(mission.X is Int64 Xvalue && mission.Y is Int64 Yvalue)
            {
                bool foundX = false; 
                bool foundY = false;

                foreach (Card card in cards)
                {
                    foundX = foundX || (Xvalue == card.Prestige);
                    foundY = foundY || (Yvalue == card.Prestige);
                }

                if(foundX && foundY) { return mission.Prestige; }
            }
            else
            {
                foreach (Card card in cards)
                {
                    if (mission.X is Int64 value && value == card.Prestige)
                    {
                        prestige += mission.Prestige;
                        if (mission.Repeat == 0) break;
                    }
                }
            }
            return prestige;
        }
        protected override bool CheckCriteria(Mission mission, int count, Card card)
        {
            return (mission.X is Int64 value && value == card.Prestige) || (mission.Y is Int64 val && val == card.Prestige);
        }
    }
}
