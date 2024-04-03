using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class MinimumPrestigeCriteria : MissionCriteria
    {
        protected override bool CheckCriteria(Mission mission, int count, Card card)
        {
            return (mission.X is int minimum && minimum <= card.Prestige);
        }
    }
}
