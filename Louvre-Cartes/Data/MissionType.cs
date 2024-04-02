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
                        Criteria = new MinimumPrestigeCriteria();
                        break;

                    case 1:
                        Criteria = new LocationCriteria();
                        break;

                    case 2:
                        Criteria = new DateCriteria();
                        break;

                    case 3:
                        Criteria = new ExactPrestigeCriteria();
                        break;

                    case 4:
                        Criteria = new TypeCriteria();
                        break;

                    case 5:
                        Criteria = new HeightCriteria();
                        break;

                    case 6:
                        Criteria = new NumberCriteria();
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
