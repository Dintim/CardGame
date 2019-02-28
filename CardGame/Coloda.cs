using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public abstract class Coloda
    {
        protected List<Card> Cards { get; set; }
        public virtual void Create()
        {
            foreach (Mast i in (Mast[])Enum.GetValues(typeof(Mast)))
            {
                foreach (Nominal j in (Nominal[])Enum.GetValues(typeof(Nominal)))
                {
                    Cards.Add(new Card() { Mast = i, Nominal = j });
                }
            }
        }

        public virtual void Shuffle()
        {
            Random rnd = new Random();
            Cards.OrderBy(x=>rnd.NextDouble()).ToList();
        }

        public void Print()
        {
            foreach (Card i in Cards)
            {
                Console.WriteLine("{0} {1}", i.Nominal, i.Mast);
            }
        }
    }
}
