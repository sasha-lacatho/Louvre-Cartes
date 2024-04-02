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
        public int MinimumNumberNeeded;

        public MinimumPrestigeCriteria(int prestige, int nbNeeded) 
        { 
            MinimumPrestige = prestige;
            MinimumNumberNeeded = nbNeeded;
        }

        public override bool CheckIsImportant(int prestige, string type, string location, int date, float height)
        {
            if(MinimumNumberNeeded <= prestige)
            {
                return true;
            }

            return false;
        }
    }
}
