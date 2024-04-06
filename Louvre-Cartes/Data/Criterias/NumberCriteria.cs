using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class NumberCriteria : MissionCriteria
    {
        public override int CalculatePrestige(Mission mission, List<Card> cards)
        {
            return mission.X is Int64 value && value <= cards.Count ? mission.Prestige : 0;
        }

        protected override bool CheckCriteria(Mission mission, int count, Card card)
        {
            return mission.X is Int64 value && value >= count + 1;
        }
    }
}
