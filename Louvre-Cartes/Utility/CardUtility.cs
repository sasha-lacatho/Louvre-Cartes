using LouvreCartes.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Utility
{
    public static class CardUtility
    {
        public static T Draw<T>(T[] drawPile, Random random)
        {
            T item;
            do
            {
                int draw = random.Next(drawPile.Length);

                item = drawPile[draw];
                drawPile[draw] = default(T);
            }
            while (item == null);

            return item;
        }
    }
}
