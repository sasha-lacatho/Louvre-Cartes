using LouvreCartes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LouvreCartes.Gameplay
{
    public class Calcul
    {
        public void SimulateOneGame(Game game)
        {
            var cards = game.Cards;
            var players = game.Players;

            for (int i = 0; i < cards.GetLength(0); i++)
            {
                // One day
                for (int cardIndex = 0; cardIndex < cards.GetLength(1); cardIndex++)
                {
                    Console.WriteLine($"\n################## CARD NUMERO {cardIndex} - JOUR : {i}");

                    // Les joueurs font leurs paris
                    int[] bids = new int[players.Length];

                    for (int j = 0; j < players.Length; j++)
                    {
                        int bid = players[j].Bid(cards[i, cardIndex]);
                        bids[j] = bid;
                        Console.WriteLine($"Mise du joueur {j} : {bids[j]}");
                    }

                    // On regarde qui a parié le +
                    int highestBid = bids.Max();
                    int highestBidPlayerIndex = Array.IndexOf(bids, highestBid);
                    Console.WriteLine($"+++++ Plus grosse mise : joueur {highestBidPlayerIndex} : {highestBid} +++++");

                    // On ajoute à la mise de côté les golds des joueurs qui n'ont pas gagné
                    for (int j = 0; j < players.Length; j++)
                    {
                        if (j != highestBidPlayerIndex)
                        {
                            players[j].SavedGold += bids[j];
                            Console.WriteLine($"Gold mise de côté du joueur {j} : {bids[j]}");
                        }

                        // On retire leurs golds
                        players[j].Gold -= bids[j];
                        Console.WriteLine($"-- Players Gold {j} : {players[j].Gold}");
                    }
                    Console.WriteLine();

                    // On offre la carte au joueur qui a gagné
                    players[highestBidPlayerIndex].Cards.Add(cards[i, cardIndex]);
                }

                //Fin de journée: on redonne les Golds aux players qui ont misé + les 30 golds
                Console.WriteLine("------------ Fin de journée");
                foreach (Player player in game.Players)
                {
                    player.Gold += player.SavedGold + 30;
                    Console.WriteLine($"--- Mise retrouvée : {player.SavedGold} " +
                        $"--- +30 golds : {player.SavedGold + 30} --- Players Gold : {player.Gold}");
                }
            }

            Console.WriteLine("\n-------------------- Fin de la partie");

            CalculatePlayersPoints(players.ToList());
        }


        public List<Player> CreatePlayers(List<Player> players, int nbPlayers, List<Card> cards)
        {
            for (int i = 1; i <= nbPlayers; i++)
            {
                List<Card> playerCards = new List<Card>();
                for (int j = 0; j < 2; j++)
                {
                    int randomCardIndex = new Random().Next(cards.Count);
                    playerCards.Add(cards[randomCardIndex]);
                }

                players.Add(new Player(i, 140, new Mission[0]));
            }

            return players;
        }

        public void CalculatePlayersPoints(List<Player> players)
        {
            // Find the player with the most gold
            Player goldWinner = players[0];
            foreach (Player player in players)
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
            foreach (Player player in players)
            {
                int totalPrestige = player.Cards.Sum(card => card.Prestige);
                if (player.GoldWinner)
                {
                    Console.WriteLine($"$$$ {player.ID} is the Gold Winner");
                    totalPrestige += 2; // Add 2 points of prestige if the player won the gold
                }
                player.TotalPrestige = totalPrestige;

                Console.WriteLine($"{player.ID} : Total Prestige - {player.TotalPrestige}");
            }
        }
    }
}
