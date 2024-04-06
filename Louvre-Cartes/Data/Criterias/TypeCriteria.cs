using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class TypeCriteria : MissionCriteria
    {
        public override int CalculatePrestige(Mission mission, List<Card> cards)
        {
            int prestige = 0;

            foreach (Card card in cards)
            {
                if ((mission.X is string value && card.Type == value) || (mission.Y is string val && val == card.Type))
                {
                    prestige += mission.Prestige;
                    if (mission.Repeat == 0) break;
                }
            }

            return prestige;
        }

        protected override bool CheckCriteria(Mission mission, int count, Card card)
        {
            return (mission.X is string value && card.Type == value) || (mission.Y is string val && val == card.Type);
        }
    }
}
