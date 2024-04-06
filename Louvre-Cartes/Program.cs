using LouvreCartes.Data;
using LouvreCartes.Gameplay;

namespace LouvreCartes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameData data = DataLoader.LoadData();
            data.Initialize();

            //data.TestAll();
            
            Console.WriteLine("\nCreating test Game :\n");

            Game game = new Game(data);

            Console.WriteLine("----------------");

            //Console.WriteLine("Extracted data :");
            //Console.WriteLine(data);

            // 1 Game
            List<Card> cards = new List<Card>();
            for (int day = 0; day < Game.NUMBER_OF_DAYS; day++)
            {
                for (int i = 0; i < Game.CARD_PER_DAY; i++)
                {
                    Card card = game.Cards[day, i];
                    cards.Add(card);
                }
            }


            Calcul testCalcul = new Calcul();
            testCalcul.SimulateOneGame(game, cards);


            Console.ReadLine();
        }
    }
}