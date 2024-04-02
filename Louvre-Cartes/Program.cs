using LouvreCartes.Data;

namespace LouvreCartes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            GameData data = DataLoader.LoadData();

            Console.WriteLine("Extracted data :");
            Console.WriteLine(data);

            Console.ReadLine();
        }
    }
}