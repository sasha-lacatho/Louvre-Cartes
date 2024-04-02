using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LouvreCartes.Data
{
    public static class DataLoader
    {
        public static GameData LoadData()
        {
            GameData gameData = null;

            // This will get the Data.json path
            string dataPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Data/Data.json";
            Console.WriteLine("Load data at : " + dataPath);
            
            //create Stream reader & Try - Catch - Finally to handle it
            StreamReader sr = new StreamReader(dataPath);
            try
            {
                //Deserialize to the GameData
                gameData = JsonConvert.DeserializeObject<GameData>(sr.ReadToEnd());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                sr.Close();
            }
            

            return gameData;
        }
    }
}
