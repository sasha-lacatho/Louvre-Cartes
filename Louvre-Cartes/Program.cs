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

            // ----- Need to Init TypeMission because it's null -----
            foreach (var mission in data.Missions)
            {
                mission.TypeMission = new MissionType();
            }

            // Init all differents missions criteria
            data.Missions[0].TypeMission.Criteria = new MinimumPrestigeCriteria(3,1);
            data.Missions[1].TypeMission.Criteria = new LocationCriteria(new string[] { "EGYPTE", "ITALIE" });
            data.Missions[2].TypeMission.Criteria = new DateCriteria(0, true, 0);
            data.Missions[3].TypeMission.Criteria = new ExactPrestigeCriteria(new int[] { 2 });
            data.Missions[4].TypeMission.Criteria = new TypeCriteria("peinture", 0);
            data.Missions[5].TypeMission.Criteria = new LocationCriteria(new string[] { "MESOPOTAMIE" });
            data.Missions[6].TypeMission.Criteria = new HeightCriteria(2f, true);
            data.Missions[7].TypeMission.Criteria = new DateCriteria(0, true, 2);
            data.Missions[8].TypeMission.Criteria = new NumberCriteria(3);
            data.Missions[9].TypeMission.Criteria = new TypeCriteria("sculpture", 2);
            data.Missions[10].TypeMission.Criteria = new TypeCriteria("peinture", 2);
            data.Missions[11].TypeMission.Criteria = new DateCriteria(0, false, 2);
            data.Missions[12].TypeMission.Criteria = new ExactPrestigeCriteria(new int[] { 1 });
            data.Missions[13].TypeMission.Criteria = new ExactPrestigeCriteria(new int[] { 2, 3 });
            data.Missions[14].TypeMission.Criteria = new HeightCriteria(2f, false);
            data.Missions[15].TypeMission.Criteria = new LocationCriteria(new string[] { "FRANCE" });
            data.Missions[16].TypeMission.Criteria = new MinimumPrestigeCriteria(0, 3);
            data.Missions[17].TypeMission.Criteria = new LocationCriteria(new string[] { "EGYPTE", "FRANCE" });

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