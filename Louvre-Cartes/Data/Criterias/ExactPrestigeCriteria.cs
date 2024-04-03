using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class ExactPrestigeCriteria : MissionCriteria
    {
        protected override bool CheckCriteria(Mission mission, int count, Card card)
        {
            return (mission.X is int value && value == card.Prestige) || (mission.Y is int val && val == card.Prestige);
        }
    }
}
