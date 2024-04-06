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
            for (int x = 0; x < NUMBER_OF_DAYS; x++)
            {
                //Console.WriteLine($"\nDAY {x + 1} :\n");
                for (int y = 0; y < CARD_PER_DAY; y++)
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

                for (int n = 0; n < PLAYER_DRAWMISSIONS; n++)
                {
                    if (n != discard) playerMissions[index++] = draws[n];
                }
                #endregion

                Players[i] = new Player(i, PLAYER_GOLD, playerMissions);

                Console.WriteLine(Players[i]);
            }

            #endregion
        }

        public void SimulateOneGame()
        {
            for (int dayIndex = 0; dayIndex < Cards.GetLength(0); dayIndex++)
            {
                // One day
                for (int cardIndex = 0; cardIndex < Cards.GetLength(1); cardIndex++)
                {
                    Console.WriteLine($"\n################## CARD NUMERO {cardIndex} - JOUR : {dayIndex}");

                    Bid(dayIndex, cardIndex);
                }

                EndOfTheDay();
            }

            Console.WriteLine("\n-------------------- Fin de la partie");

            CalculatePlayersPoints();
        }

        private void Bid(int dayIndex, int cardIndex)
        {
            // Les joueurs font leurs paris
            int[] bids = new int[Players.Length];

            for (int j = 0; j < Players.Length; j++)
            {
                int bid = Players[j].Bid(Cards[dayIndex, cardIndex]);
                bids[j] = bid;
                Console.WriteLine($"Mise du joueur {j} : {bids[j]}");
            }

            // On regarde qui a parié le +
            int highestBid = bids.Max();
            int highestBidPlayerIndex = Array.IndexOf(bids, highestBid);
            Console.WriteLine($"+++++ Plus grosse mise : joueur {highestBidPlayerIndex} : {highestBid} +++++");

            // On ajoute à la mise de côté les golds des joueurs qui n'ont pas gagné
            for (int j = 0; j < Players.Length; j++)
            {
                if (j != highestBidPlayerIndex)
                {
                    Players[j].SavedGold += bids[j];
                    Console.WriteLine($"Gold mise de côté du joueur {j} : {bids[j]}");
                }

                // On retire leurs golds
                Players[j].Gold -= bids[j];
                Console.WriteLine($"-- Players Gold {j} : {Players[j].Gold}");
            }
            Console.WriteLine();

            // On offre la carte au joueur qui a gagné
            Players[highestBidPlayerIndex].Cards.Add(Cards[dayIndex, cardIndex]);
        }

        private void EndOfTheDay()
        {
            //Fin de journée: on redonne les Golds aux players qui ont misé + les 30 golds
            Console.WriteLine("------------ Fin de journée");
            foreach (Player player in Players)
            {
                player.Gold += player.SavedGold + 30;
                Console.WriteLine($"--- Mise retrouvée : {player.SavedGold} " +
                    $"--- +30 golds : {player.SavedGold + 30} --- Players Gold : {player.Gold}");
            }
        }

        public void CalculatePlayersPoints()
        {
            // Find the player with the most gold
            Player goldWinner = Players[0];
            foreach (Player player in Players)
            {
                if (player.Gold > goldWinner.Gold)
                {
                    goldWinner = player;
                }
            }

            // Set the GoldWinner for the player with the most gold
            goldWinner.GoldWinner = true;

            // Calculate and display total prestige for each player after the game
            Console.WriteLine("Total prestige for each player after the game:");
            foreach (Player player in Players)
            {
                int cardPrestige = player.Cards.Sum(card => card.Prestige);

                int missionPrestige = 0;
                foreach (Mission mission in player.Missions)
                {
                    missionPrestige += mission.CalculatePrestige(player.Cards);
                }

                player.TotalPrestige = cardPrestige + missionPrestige;

                if (player.GoldWinner) player.TotalPrestige += 2; // Add 2 points of prestige if the player won the gold

                Console.WriteLine($"{player.ID} : Cards {cardPrestige} + Missions {missionPrestige}{(player.GoldWinner ? " + Gold 2" : "")} = {player.TotalPrestige}");
            }
        }
    }
}
