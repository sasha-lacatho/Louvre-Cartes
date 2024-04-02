using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class ExactPrestigeCriteria : MissionCriteria
    {
        public int[] ExactPrestige;

        public ExactPrestigeCriteria(int[] prestige)
        {
            ExactPrestige = prestige;
        }
    }
}
