using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public enum Mast { chervi, kresti, bubi, piki}
    public enum Nominal { six=6, seven, eigth, nine, ten, valet, dama, korol, tuz}
    public class Card
    {
        public Mast Mast { get; set; }
        public Nominal Nominal { get; set; }

        public void PrintCard()
        {
            Console.Write("{0} {1}\t", Nominal, Mast);
        }
    }
}
