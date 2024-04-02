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
        private bool[] _treatedLocations;

        public LocationCriteria(string[] locations)
        {
            Locations = locations;

            _treatedLocations = new bool[locations.Length];
        }

        public override bool CheckIsImportant(int prestige, string type, string location, int date, float height)
        {
            for (int i = 0; i < Locations.Length; i++)
            {
                if (!_treatedLocations[i] && Locations[i] == location)
                {
                    // Marquer la location comme traitée
                    _treatedLocations[i] = true;
                    return true;
                }
            }
            return false;
        }
    }
}
