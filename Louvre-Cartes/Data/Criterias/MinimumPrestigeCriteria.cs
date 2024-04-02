using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class MinimumPrestigeCriteria : MissionCriteria
    {
        public int MinimumPrestige;

        public MinimumPrestigeCriteria(int prestige) 
        { 
            MinimumPrestige = prestige;
        }
    }
}
