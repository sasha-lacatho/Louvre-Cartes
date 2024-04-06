using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class LocationCriteria : MissionCriteria
    {
        public override int CalculatePrestige(Mission mission, List<Card> cards)
        {
            int prestige = 0;

            if (mission.X is string Xvalue && !string.IsNullOrEmpty(Xvalue) && mission.Y is string Yvalue && !string.IsNullOrEmpty(Yvalue))
            {
                bool foundX = false;
                bool foundY = false;

                foreach (Card card in cards)
                {
                    foundX = foundX || (Xvalue == card.Location);
                    foundY = foundY || (Yvalue == card.Location);
                }

                if (foundX && foundY) { return mission.Prestige; }
            }
            else
            {
                foreach (Card card in cards)
                {
                    if (mission.X is string value && value == card.Location)
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
            return (mission.X is string value && value == card.Location) || (mission.Y is string val && val == card.Location);
        }
    }
}
