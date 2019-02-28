using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Game:Coloda
    {
        public Game()
        {
            base.Cards = new List<Card>();
            base.Create();
        }
        public List<Player> Players;

        public void CreatePlayers(int count=2)
        {
            if (count < 2)
                throw new Exception("Сам с собой не играй");
            Players = new List<Player>();
            for (int i = 0; i < count; i++)
            {
                Player player = new Player();
                player.Id = i;
                player.Name = "Player " + i;
                Players.Add(player);
            } 
        }

        public void Razdacha()
        {
            int k = Players.Count-1;
            int x = 0;
            foreach (Card i in Cards)
            {
                if (x > k)
                    x = 0;
                Players[x++].Cards.Push(i);                
            }
        }

        public Player StartGame()
        {
            CreatePlayers();
            Shuffle();
            Razdacha();
            
            Dictionary<Player, Card> dic = new Dictionary<Player, Card>();
            int maxCard = 0;
            Player winner = null;
            while (!Players.Any(a=>a.Cards.Count==36))
            {                
                foreach (Player i in Players)
                {
                    i.Cards.Peek().PrintCard();
                    dic.Add(i, i.Cards.Pop());                    
                }
                Console.WriteLine("");

                foreach (var i in dic)
                {
                    if ((int)i.Value.Nominal>maxCard)
                    {
                        maxCard = (int)i.Value.Nominal;
                        winner = i.Key;
                    }
                }
                winner.PrintInfo();

                foreach (var i in dic)
                {
                    Players[winner.Id].Cards.Push(i.Value);
                }
                maxCard = 0;
                winner = null;
                dic = new Dictionary<Player, Card>();
            }

            return Players.FirstOrDefault(x => x.Cards.Count == 36);
        }

    }
}
