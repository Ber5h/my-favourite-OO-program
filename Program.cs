using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _помогите_
{

    enum Cards
    {
        Шестерка, Семерка,
        Восьмерка, Девятка, Десятка, Валет, Дама, Король, Туз
    }
    class Program
    {
        static void Main(string[] args)
        {
            Card deck1 = new Card();

        }
    }
    class Card //вроде даже все написал
    {/*короче нужно записывать сюда карты, которые участвуют в войне в закрытую */
        private Cards[] deck;
        static Random rnd = new Random();
        public Card()
        {
            deck = new Cards[36];
            int i = 0;
            for (Cards k = Cards.Шестерка; k <= Cards.Туз;)
            {
                deck[i] = k;
                i++;
                if (i % 4 == 0) k++;
            }
        }
        public Cards Return_card(int i)
        {
            return deck[i];
        }
        public void Shuffle()
        {
            int[] num_cards = { 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            int a;
            for (int i = 0; i < 36; i++)
            {
                a = rnd.Next(0, 8);
                while (num_cards[a] == 0)
                {
                    a = rnd.Next(0, 8);
                }
                num_cards[a]--;
                deck[i] = (Cards)(a);
            }
        }
        public Cards[] Deck
        {
            get
            {
                return deck;
            }
        }
        public void Add_card(int i, Player player1)
        {
            Cards[] helpless_mas = { deck[i] };
            player1.Deck = helpless_mas;
            deck[i] = 0;
        }
        public void War(Cards[] deck_war)
        {
            int i = 0;
            foreach (int x in deck_war)
            {
                deck[i] = x;
                i++;
            }
        }
    }
    class Player
    {
        private Cards[] deck;
        public Player()
        {
            deck = new Cards[36];
            //могу себе позволить творить все, что угодно, поэтому буду добавлять карты игроку не здесь
        }
        public Cards[] Deck //будет вызываться в Main'е
        {
            set
            {
                Redact_deck(value[0]/*обожаю извращения*/, I);

            }
            get
            {
                return deck;
            }
        }

        private void Redact_deck(Cards card, int i)
        {
            deck[i] = card;
        }
        public int I
        {
            get
            {
                int i = 0;
                foreach (Cards x in deck)
                {
                    if (x == 0) return i;
                    i++;
                }
                return 36;
            }
        }
        public bool Fullness //мб и не нужно это, но пусть будет
        {
            get
            {
                if (I == 18) return true;
                else return false;
            }
        }
        public int Num_cards
        {
            get
            {
                int i = 0;
                foreach (Cards x in deck)
                {
                    if (x != 0) i++;
                }
                return i;
            }
        }
        //public void Shift (int a, Cards add_mas)//a - длина изменений
        //{
        //    Cards[] mas_temp = new Cards[deck.Length+a];
        //    int i = 0;
        //    foreach (Cards x in deck)
        //    {
        //        if (x!=0)
        //    }
        //}
    }
}


