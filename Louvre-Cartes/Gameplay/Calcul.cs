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
        public void MainTest()
        {
            // Liste des cartes à reprendre des datas
            List<Card> cards = new List<Card>
            {
                new Card { Name = "Card 1", Prestige = 3 },
                new Card { Name = "Card 2", Prestige = 2 },
            };

            int nbPlayers = 3;
            int totalGames = 1000;


            // Create players
            List<Player> players = new List<Player>();
            players = CreatePlayers(players, nbPlayers, cards);



            Random random = new Random();

            // Simulate games
            // ...

            CalculatePlayersPoints(players);
        }

        public void SimulateOneDay(Game game, List<Card> cards) // (List<Player> players) //List<Card> threeCards
        {
            //boucle de Bid
            for (int i = 0; i < 3; i++)
            {
                // Les joueurs font leurs paris
                int[] bids = new int[game.Players.Length];
                
                Random random = new Random();
                for (int j = 0; j < game.Players.Length; j++)
                {
                    int bid = game.Players[j].Bid(cards[i]);
                    bids[j] = bid;
                    Console.WriteLine($"Mise du joueur {j} : {bids[j]}");
                }

                // On regarde qui a parié le +
                int highestBid = bids.Max();
                int highestBidPlayerIndex = Array.IndexOf(bids, highestBid);
                Console.WriteLine($"Plus gross mise : joueur {highestBidPlayerIndex} : {highestBid}");

                // On ajoute à la mise de côté les golds des joueurs qui n'ont pas gagné
                for (int j = 0; j < game.Players.Length; j++)
                {
                    if (j != highestBidPlayerIndex)
                    {
                        game.Players[j].SavedGold += bids[j];
                        Console.WriteLine($"Gold mise de côté du joueur {j} : {bids[j]}");
                    }
                    // On retire leurs golds
                    game.Players[j].Gold -= bids[j];
                    Console.WriteLine($"-- Players Gold {j} : {game.Players[j].Gold}");
                    Console.WriteLine();

                }

                // On offre la carte au joueur qui a gagné
                //...

            }

            //Fin de journée: on redonne les Golds aux players qui ont misé + les 30 golds
            foreach (Player player in game.Players)
            {
                player.Gold += player.SavedGold + 30;
                Console.WriteLine($"--- Mise retrouvée : {player.SavedGold} --- +30 golds : {player.SavedGold + 30} --- Players Gold : {player.Gold}");
            }
        }




        // Function to determine if a card is important for the player's missions
        public bool IsImportantForMissions(Card card)
        {
            Random random = new Random();
            return random.Next(2) == 0; // Random simulation
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

            // Set the GoldWinner flag for the player with the most gold
            goldWinner.GoldWinner = true;

            // Calculate and display total prestige for each player after the games
            Console.WriteLine("Total prestige for each player after the games:");
            foreach (Player player in players)
            {
                int totalPrestige = player.Cards.Sum(card => card.Prestige);
                if (player.GoldWinner)
                {
                    totalPrestige += 2; // Add 2 points of prestige if the player won the gold
                }
                player.TotalPrestige = totalPrestige;

                Console.WriteLine($"{player.ID} : Total Prestige - {player.TotalPrestige}");
            }
        }
    }
}
