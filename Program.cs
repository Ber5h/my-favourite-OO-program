using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _помогите_
{

    enum Cards
    {
        Шестерка = 1, Семерка, //мб с 0 начинать, я не помню, как код работает
        Восьмерка, Девятка, Десятка, Валет, Дама, Король, Туз
    }
    class Program
    {
        public static void War (Player player1, Player player2, Card deck)
        {
            Console.WriteLine("Война капсом");
            Console.WriteLine("Игроки выложили по карте в закрытую");
            if (player1 & player2) Compare(player1, player2, deck);
            else
            {
                Console.WriteLine("Карты закончились");
                End(player1, player2);
            }
        }
        static void End (Player player1, Player player2)
        {
            if (player1) Console.WriteLine("Победил первый игрок");
            else Console.WriteLine("Победил второй игрок");
            //и отсылает к меню
            Menu();
        }
        static void Compare (Player player1, Player player2, Card deck1)
        {
            Console.WriteLine("От первого игрока карта достоинства: {0}", player1[0]);
            Console.WriteLine("От второго игрока карта достоинства: {0}", player2[0]);
            Player.Compare(player1, player2, deck1);
        }
        public static void InterfaceForWar (Player player1, Player player2, Card deck)
        {
            //здесь проверка, есть ли карты в колоде
            if (deck.Num_cards == 0)
            {
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i<deck.Num_cards; i++)
                {
                    Console.Write(", {0}", deck[i]);
                }
                Console.WriteLine();
            }
        }
        static void Game()
        {
            Card deck1 = new Card();
            deck1.Shuffle();
            Player player1 = new Player();
            Player player2 = new Player();
            for (int i = 0; i < 36; i++)
            {
                if (i % 2 == 0) deck1.Add_card(i, player1);
                else deck1.Add_card(i, player2);
            }
            while (player1 & player2)
            {
                Console.WriteLine("Следующий тур капсом");
                Compare(player1, player2, deck1);
            }
            End(player1, player2);
        }
        static void Menu()
        {
            Console.WriteLine("Ну че, народ, погнали? (введите 1, если хотите начать игру)");
            string a = Console.ReadLine();
            if (a == "1") Game();
            else if (a == "42")
            {
                Console.WriteLine("Анекдот: в дверь постучались 6 раз. 'Надо делать выводы,'- подумал Штирлиц");
                Menu();
                  }
            else
            {
                Console.WriteLine("Тут нет интерфейса, просто введите 1 или выйдите из консоли");
                Menu();
            }
        }
        static void Main(string[] args)
        {
            Menu();
            Console.ReadKey();
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
                a = rnd.Next(1, 10);
                while (num_cards[a-1] == 0)
                {
                    a = rnd.Next(1, 10);
                }
                num_cards[a-1]--;
                deck[i] = (Cards)(a);
            }
        }
        public void Output ()
        {
            foreach (Cards x in deck)
            {
                Console.WriteLine(x);
            }
        }
        public Cards[] Deck
        {
            get
            {
                return deck;
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
        public void Add_card(int i, Player player1)
        {
            Cards[] helpless_mas = { deck[i] };
            player1.Deck = helpless_mas;
            deck[i] = 0;
        }
        public void War(Cards[] deck_war) //на время войны вводит в колоду карты, которые участвуют в войне
        {

            int i = Num_cards;
            foreach (Cards x in deck_war)
            {
                deck[i] = x;
                i++;
            }
            
            //тут все правильно
        }
        public Cards this [int j]
        {
            get
            {
                return deck[j];
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
        public Cards[] Deck
        {
            set
            {
                Redact_deck(value[0], I); //АХАХАХХАХХА ПОМОГИТЕ

            }
            get
            {
                return deck;
            }
        }

        private void Redact_deck(Cards card, int i)
        {
            try
            {
                deck[i] = card;
            }
            catch
            {
                deck = Shift(1, deck);
                Deck = new Cards[] { card };
            }
        }
        public int I
        {
            get
            {
                int i = 0;
                foreach (Cards x in deck)
                {
                    if ((int)x == 0) return i;
                    i++;
                }
                return 36;
            }
        }

        
        private static void Add_card (Player player1, Card deck)
        {
            int i = 0;
            while (deck.Num_cards > 0)
            {
               
                deck.Add_card(i, player1);
                i++;
            }
        }
        public static void Compare(Player player1, Player player2, Card deck)
        {
            Cards a2_temp = player2[0];
            Cards a1_temp = player1[0];
            //все я правильно делаю, потом чисто из колоды добавить тому, кто крутой
            if (a1_temp > a2_temp)
            {
                Console.Write("Первый игрок выиграл тур и получил {0}, {1}", player1[0], player2[0]);
                Program.InterfaceForWar(player1, player2, deck);
                Add_card(player1, deck);
                    player2[0] = 0;
                 player2.deck =   Shift(1, player2.deck);

                    player1[0] = 0;
                    Cards[] mas_temp = { a1_temp, a2_temp }; //АХАХХАХАХХАХАХА
                 player1.deck =    Shift(1, mas_temp, player1.deck);
                player1.deck = Shift(deck.Num_cards, deck.Deck, player1.deck);
                
            }
            else if (a2_temp > a1_temp)
            {
                Console.Write("Второй игрок выиграл тур и получил {0}, {1}", player1[0], player2[0]);
                Program.InterfaceForWar(player1, player2, deck);
                Add_card(player2, deck);
                player1[0] = 0;
               player1.deck =  Shift(1, player1.deck);
                player2[0] = 0;
                Cards[] mas_temp = { a2_temp, a1_temp };
                player2.deck = Shift(1, mas_temp, player2.deck);
                player2.deck = Shift(deck.Num_cards, deck.Deck, player2.deck);
            }
            else
            {
                //о нет
                //ААААА ТОЛЬКО НЕ ЭТО
                //Helpme
                deck.War(new Cards[] { player1[0], player1[1], player2[0], player2[1] });
               
                player1.deck = Shift(2, player1.deck);
                player2.deck = Shift(2, player2.deck);
                Program.War(player1, player2, deck);
            }
        }
        //я не понимаю, как мой код работает, но вроде бы мне ток Main остался
        private static Cards[] Shift(int a, Cards[] add_mas, Cards[] deck)//a - длина изменений
        {
            Cards[] mas_temp = new Cards[36];
            int i = 0;
            foreach (Cards x in deck)
            {
                if (x != 0)
                {
                    try
                    {
                        mas_temp[i] = x;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                    i++;
                }

            }
            foreach (Cards x in add_mas)
            {
                try
                {
                    mas_temp[i] = x;
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
                i++;
            }
            
            return mas_temp;
        }
        // я хотел перегрузить Shift, вспомнил
        private static Cards[] Shift (int a,Cards[] deck)
        {
            
                Cards[] mas = new Cards[36];
            
            int j = 0;
            for (int i = a; i<deck.Length-a; i++)
            {
                mas[j] = deck[i];
                j++;
            }
            return mas;
        }
        //public static bool operator > (Player obj1, Player obj2)
        //{
        //   return ((int)obj1.deck[0] > (int)obj2.deck[0]) ;
        //}
        //public static bool operator < (Player obj1, Player obj2)
        //{
        //    return ((int)obj1.deck[0] < (int)obj2.deck[0]);
        //}
        //равно будет в виде else
        public static bool operator true(Player obj1)
        {
            return (obj1.I > 0);
        }
        public static bool operator false(Player obj1)
        {
            return (obj1.I == 0);
        }
        public static bool operator & (Player obj1, Player obj2)
        {
            return (obj1.I > 0 & obj2.I > 0);
        }
        public Cards this[int i]
        {
            get
            {
                return deck[i];
            }
            set
            {
                deck[i] = value;
            }
        }
    }
}
