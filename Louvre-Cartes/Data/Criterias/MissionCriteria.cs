using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public abstract class MissionCriteria
    {
        public abstract bool CheckIsImportant(int prestige, string type, string location, int date, float height);
    }
}
