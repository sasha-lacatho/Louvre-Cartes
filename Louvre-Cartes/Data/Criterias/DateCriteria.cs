using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class DateCriteria : MissionCriteria
    {
        protected override bool CheckCriteria(Mission mission, int count, Card card)
        {
            bool inferior = mission.X is int value && value == 0;
            return inferior ? (card.Date <= 0) : (card.Date >= 0);
        }
    }
}
