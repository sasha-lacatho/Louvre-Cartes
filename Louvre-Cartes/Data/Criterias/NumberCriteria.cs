using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class NumberCriteria : MissionCriteria
    {
        public int ExactNumber;
        private int _currentNumber;

        public NumberCriteria(int exactNumber)
        {
            ExactNumber = exactNumber;
            _currentNumber = 0;
        }

        public override bool CheckIsImportant(int prestige, string type, string location, int date, float height)
        {
            if(_currentNumber < ExactNumber)
            {
                _currentNumber++;
                return true;
            }

            return false;
        }
    }
}
