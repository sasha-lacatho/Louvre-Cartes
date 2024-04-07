using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Data
{
    public struct WinRate
    {
        public int Games;
        public int Wins;
        public float Ratio => Wins / (float)Games;
        public string RatioText => $"[{(int)((Wins / (float)Games) * 100)}%] [{Wins}/{Games}]";
    }
}
