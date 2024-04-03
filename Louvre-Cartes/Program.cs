using LouvreCartes.Data;
using LouvreCartes.Gameplay;

namespace LouvreCartes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameData data = DataLoader.LoadData();

            Console.WriteLine("\nCreating test Game :\n");

            Game game = new Game(data);

            Console.WriteLine("----------------");

            //Console.WriteLine("Extracted data :");
            //Console.WriteLine(data);

            //Console.WriteLine("data length " + data.Missions.Length);
            //Console.WriteLine("data typemission 0 : " + data.Missions[0].TypeMission);


            //Exemple
            List<Card> cards = new List<Card>();
            for (int day = 0; day < Game.NUMBER_OF_DAYS; day++)
            {
                Card card0 = game.Cards[day, 0];
                Card card1 = game.Cards[day, 1];
                Card card2 = game.Cards[day, 2];
                cards.Add(card0);
                cards.Add(card1);
                cards.Add(card2);
            }


            Calcul testCalcul = new Calcul();
            testCalcul.SimulateOneDay(game, cards);


            Console.ReadLine();
        }
    }
}