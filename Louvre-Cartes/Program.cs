using LouvreCartes.Data;
using LouvreCartes.Gameplay;

namespace LouvreCartes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            GameData data = DataLoader.LoadData();

            Console.WriteLine("\nCreating test Game :\n");

            Game game = new Game(data);


            Calcul test = new Calcul();
            test.SimulateOneDay(game);

            //Console.WriteLine("Extracted data :");
            //Console.WriteLine(data);




            Console.ReadLine();
        }
    }
}