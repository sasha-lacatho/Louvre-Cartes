using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public class Card
    {
        public string Name;
        public int Prestige;
        public string Type;
        public string Location;
        public int Date;
        public float Height;

        public override string ToString()
        {
            return $"{GetType().Name} : {Name} :\n - P.{Prestige}, T.{Type}, L.{Location}, D.{Date}, H.{Height}";
        }
    }
}
