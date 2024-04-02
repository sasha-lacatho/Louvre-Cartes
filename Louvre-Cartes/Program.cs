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

            Calcul test = new Calcul();
            test.SimulateOneDay();

            //Console.WriteLine("Extracted data :");
            //Console.WriteLine(data);

            Console.ReadLine();
        }
    }
}