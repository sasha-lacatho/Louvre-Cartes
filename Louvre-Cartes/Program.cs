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

            Calcul testCalcul = new Calcul();
            testCalcul.SimulateOneGame(game);


            Console.ReadLine();
        }
    }
}