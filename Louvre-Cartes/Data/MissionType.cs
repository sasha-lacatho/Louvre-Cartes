using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class MissionType
    {
        private int _type;
        public int Type 
        {
            get => _type; 
            set 
            {
                _type = value;
                #region Switch on Criteria type
                switch (value)
                {
                    case 0:
                        Criteria = new MinimumPrestigeCriteria(0, 0);
                        break;

                    case 1:
                        Criteria = new LocationCriteria(new string[] {});
                        break;

                    case 2:
                        Criteria = new DateCriteria(0, false, 0);
                        break;

                    case 3:
                        Criteria = new ExactPrestigeCriteria(new int[] {});
                        break;

                    case 4:
                        Criteria = new TypeCriteria(String.Empty, 0);
                        break;

                    case 5:
                        Criteria = new HeightCriteria(0, false);
                        break;

                    case 6:
                        Criteria = new NumberCriteria(0);
                        break;
                }
                #endregion
            }
        }

        public string Description;
        public MissionCriteria Criteria;

        public override string ToString()
        {
            return $"{GetType().Name} : {Type} :\n - {Description}\n - Criteria : {Criteria.GetType().Name.Replace("Criteria", null)}";
        }
    }
}
