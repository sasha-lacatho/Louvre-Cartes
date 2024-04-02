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
        public static void Main()
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
            for (int i = 0; i < totalGames; i++)
            {
                foreach (Card card in cards)
                {
                    List<Player> playersInAuction = new List<Player>(players);

                    // Each player makes a bid
                    Dictionary<Player, int> bids = new Dictionary<Player, int>();
                    foreach (Player player in players)
                    {
                        int bid = player.Bid(card);
                        bids.Add(player, bid);
                    }

                    // Determine the player with the highest bid
                    Player highestBidder = bids.OrderByDescending(kv => kv.Value).First().Key;
                    int highestBid = bids[highestBidder];

                    // The highest bidder wins the card and pays the bid amount
                    highestBidder.Gold -= highestBid;

                    // Remove the highest bidder from the list of players in the auction
                    playersInAuction.Remove(highestBidder);

                    // All other players lose their bids
                    foreach (Player player in playersInAuction)
                    {
                        player.Gold -= bids[player];
                    }

                    // Assign the card to the highest bidder
                    highestBidder.Cards.Add(card);
                }

                // At the end of the day, players recover their gold in transit and each gain 30 gold coins
                foreach (Player player in players)
                {
                    player.Gold += 30;
                }

                //foreach (Player player in players)
                //{
                //    player.Gold += player.GoldInTransit;
                //    player.GoldInTransit = 0;
                //}
            }

            CalculatePlayersPoints(players);
        }

        // Function to determine if a card is important for the player's missions
        public static bool IsImportantForMissions(Card card)
        {
            Random random = new Random();
            return random.Next(2) == 0; // Random simulation
        }

        public static List<Player> CreatePlayers(List<Player> players, int nbPlayers, List<Card> cards)
        {
            for (int i = 1; i <= nbPlayers; i++)
            {
                List<Card> playerCards = new List<Card>();
                for (int j = 0; j < 2; j++)
                {
                    int randomCardIndex = new Random().Next(cards.Count);
                    playerCards.Add(cards[randomCardIndex]);
                }

                players.Add(new Player { Name = $"Player {i}", Gold = 140, Cards = playerCards });
            }

            return players;
        }

        public static void CalculatePlayersPoints(List<Player> players)
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

                Console.WriteLine($"{player.Name}: Total Prestige - {player.TotalPrestige}");
            }
        }
    }
}
