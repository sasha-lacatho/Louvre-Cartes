using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public abstract class MissionCriteria
    {
        public bool IsImportant(Mission mission, ICollection<Card> cards, Card card)
        {
            int count = cards.Count;
            if(mission.Repeat == 0)
            {
                foreach(Card item in cards)
                {
                    if(CheckCriteria(mission, count - 1, item)) return false;
                }
            }
            return CheckCriteria(mission, count, card);
        }
        protected abstract bool CheckCriteria(Mission mission, int count, Card card);

        public abstract int CalculatePrestige(Mission mission, List<Card> cards);
    }
}
