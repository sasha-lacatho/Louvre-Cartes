using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class TypeCriteria : MissionCriteria
    {
        public string Type;
        public int MinimumNumber;

        public TypeCriteria(string type, int minimumNumber)
        {
            Type = type;
            MinimumNumber = minimumNumber;
        }
        
        public override bool CheckIsImportant(int prestige, string type, string location, int date, float height)
        {
            return Type == type;
        }
    }
}
