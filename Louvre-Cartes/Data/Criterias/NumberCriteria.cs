using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class NumberCriteria : MissionCriteria
    {
        public int NumberNeeded;
        public bool IsNeededToBeExact;

        public NumberCriteria(int exactNumber, bool isNeededToBeExact)
        {
            NumberNeeded = exactNumber;
            IsNeededToBeExact = isNeededToBeExact;
        }
    }
}
