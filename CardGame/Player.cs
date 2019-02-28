using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player
    {
        public Player()
        {
            Cards = new Stack<Card>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Stack<Card> Cards;

        public void PrintInfo()
        {
            Console.WriteLine("-> {0}", Name);
        }
        
    }
}
