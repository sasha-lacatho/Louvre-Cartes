using LouvreCartes.Data;
using LouvreCartes.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Gameplay
{
    public class Game
    {
        public const int NUMBER_OF_DAYS = 3;
        public const int CARD_PER_DAY = 3;
        public const int PLAYER_COUNT = 3;
        public const int PLAYER_DRAWMISSIONS = 3;
        public const int PLAYER_MISSIONS = 2;

        public const int PLAYER_GOLD = 140;


        public Card[,] Cards; //X = day
        public Player[] Players; //X = day



        public Game(GameData data)
        {
            Random random = new Random(Environment.TickCount);

            #region Pick Auction Cards
            // create copy of all cards
            Card[] cardPile = new Card[data.Cards.Length];
            data.Cards.CopyTo(cardPile, 0);

            Cards = new Card[NUMBER_OF_DAYS, CARD_PER_DAY];
            for(int x = 0;  x < NUMBER_OF_DAYS; x++)
            {
                //Console.WriteLine($"\nDAY {x + 1} :\n");
                for(int y = 0;  y < CARD_PER_DAY; y++)
                {
                    Cards[x, y] = CardUtility.Draw(cardPile, random);
                }
            }
            #endregion

            #region Create Players
            Players = new Player[3];
            Mission[] playerMissions = new Mission[PLAYER_MISSIONS];

            // create copy of all missions
            Mission[] missionPile = new Mission[data.Missions.Length];
            data.Missions.CopyTo(missionPile, 0);

            Console.WriteLine("Players :\n");

            for (int i = 0; i < PLAYER_COUNT; i++)
            {
                #region Draw 3, discard 1 Mission
                Mission[] draws = new Mission[PLAYER_DRAWMISSIONS];
                for (int n = 0; n < PLAYER_DRAWMISSIONS; n++)
                {
                    draws[n] = CardUtility.Draw(missionPile, random);
                }
                int discard = random.Next(PLAYER_DRAWMISSIONS);
                int index = 0;

                for(int n = 0; n < PLAYER_DRAWMISSIONS; n++) 
                {
                    if(n != discard) playerMissions[index++] = draws[n];
                }
                #endregion

                Players[i] = new Player(i, PLAYER_GOLD, playerMissions);

                Console.WriteLine(Players[i]);
            }

            #endregion
        }
    }
}
