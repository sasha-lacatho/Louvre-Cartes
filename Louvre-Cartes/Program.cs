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

            Console.WriteLine("----------------");

            //Calcul test = new Calcul();
            //test.SimulateOneDay(game);

            //Console.WriteLine("Extracted data :");
            //Console.WriteLine(data);

            data.Missions[0].TypeMission.Criteria = new MinimumPrestigeCriteria(3);
            data.Missions[1].TypeMission.Criteria = new LocationCriteria(new string[] { "EGYPTE", "ITALIE" });
            data.Missions[2].TypeMission.Criteria = new DateCriteria(0, true, 0);
            data.Missions[3].TypeMission.Criteria = new ExactPrestigeCriteria(new int[] { 2 });
            data.Missions[4].TypeMission.Criteria = new TypeCriteria("peinture", 0);
            data.Missions[5].TypeMission.Criteria = new LocationCriteria(new string[] { "MESOPOTAMIE" });
            data.Missions[6].TypeMission.Criteria = new HeightCriteria(2f, true);
            data.Missions[7].TypeMission.Criteria = new DateCriteria(0, true, 2);
            data.Missions[8].TypeMission.Criteria = new NumberCriteria(3, true);
            data.Missions[9].TypeMission.Criteria = new TypeCriteria("sculpture", 2);
            data.Missions[10].TypeMission.Criteria = new TypeCriteria("peinture", 2);
            data.Missions[11].TypeMission.Criteria = new DateCriteria(0, false, 2);
            data.Missions[12].TypeMission.Criteria = new ExactPrestigeCriteria(new int[] { 1 });
            data.Missions[13].TypeMission.Criteria = new ExactPrestigeCriteria(new int[] { 2, 3 });
            data.Missions[14].TypeMission.Criteria = new HeightCriteria(2f, false);
            data.Missions[15].TypeMission.Criteria = new LocationCriteria(new string[] { "FRANCE" });
            data.Missions[16].TypeMission.Criteria = new NumberCriteria(3, false);
            data.Missions[17].TypeMission.Criteria = new LocationCriteria(new string[] { "EGYPTE", "FRANCE" });


            Console.ReadLine();
        }
    }
}