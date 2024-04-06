using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class HeightCriteria : MissionCriteria
    {
        protected override bool CheckCriteria(Mission mission, int count, Card card)
        {
            bool inferior = mission.X is Int64 value && value == 0;
            return inferior ? (card.Height <= 200) : (card.Height >= 200);
        }
    }
}
