using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class DateCriteria : MissionCriteria
    {
        public int MinimumDate;
        public bool IsInferior;
        public int MinimumNeeded;

        public DateCriteria(int date, bool isInferior, int minimumNeeded)
        {
            MinimumDate = date;
            IsInferior = isInferior;
            MinimumNeeded = minimumNeeded;
        }
    }
}
