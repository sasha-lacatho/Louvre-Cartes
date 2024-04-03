using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class LocationCriteria : MissionCriteria
    {
        protected override bool CheckCriteria(Mission mission, int count, Card card)
        {
            return (mission.X is string value && value == card.Location) || (mission.Y is string val && val == card.Location);
        }
    }
}
