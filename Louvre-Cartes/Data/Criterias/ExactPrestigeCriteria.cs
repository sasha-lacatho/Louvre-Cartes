using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class ExactPrestigeCriteria : MissionCriteria
    {
        public int[] ExactPrestige;
        private bool[] _treatedPrestiges;

        public ExactPrestigeCriteria(int[] prestige)
        {
            ExactPrestige = prestige;

            _treatedPrestiges = new bool[prestige.Length];
        }

        public override bool CheckIsImportant(int prestige, string type, string location, int date, float height)
        {
            for (int i = 0; i < ExactPrestige.Length; i++)
            {
                if (!_treatedPrestiges[i] && ExactPrestige[i] == prestige)
                {
                    // Marquer le prestige comme traité
                    _treatedPrestiges[i] = true;
                    return true;
                }
            }
            return false;
        }
    }
}
