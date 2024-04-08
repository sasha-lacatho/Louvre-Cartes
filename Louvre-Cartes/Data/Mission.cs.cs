using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LouvreCartes.Data
{
    public class Mission
    {
        public string Text { get; set; }
        public int Prestige { get; set; }
        public int Type { get; set; }
        public object X { get; set; }
        public object Y { get; set; }
        public int Repeat { get; set; }
        public MissionCriteria Criteria;

        public WinRate WinRate;

        public int ID { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name} : {Text} :\n - P.{Prestige}, T.{Type}, [X.{X}, Y.{Y}], R.{Repeat}";
        }

        public int CalculatePrestige(List<Card> cards)
        {
            return Criteria.CalculatePrestige(this, cards);
        }
    }
}
