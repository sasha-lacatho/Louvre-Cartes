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
        public string Text;
        public int Prestige;
        public int Type;
        public object X;
        public object Y;
        public int Repeat;

        public override string ToString()
        {
            return $"{GetType().Name} : {Text} :\n - P.{Prestige}, T.{Type}, [X.{X}, Y.{Y}], R.{Repeat}";
        }
    }
}
