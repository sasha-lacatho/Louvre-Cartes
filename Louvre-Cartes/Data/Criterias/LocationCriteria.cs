using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class LocationCriteria : MissionCriteria
    {
        public string[] Locations;

        public LocationCriteria(string[] locations)
        {
            Locations = locations;
        }
    }
}
