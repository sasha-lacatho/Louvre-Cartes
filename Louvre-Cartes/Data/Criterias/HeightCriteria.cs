using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class HeightCriteria : MissionCriteria
    {
        public float Height;
        public bool IsInferior;

        public HeightCriteria(float height, bool isInferior)
        {
            Height = height;
            IsInferior = isInferior;
        }

        public override bool CheckIsImportant(int prestige, string type, string location, int date, float height)
        {
            if((IsInferior && height < Height) || (!IsInferior && height > Height))
            {
                return true;
            }

            return false;
        }
    }
}
