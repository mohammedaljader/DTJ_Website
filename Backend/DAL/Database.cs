using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Database
    {
        private MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;database=trello");

        public List<Card> GetAllCards()
        {
            string quary = @"SELECT card_id, card_title FROM `card`";
            List<Card> getAllCards = new List<Card>();
            try
            {
                using (connection)
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(quary, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                Card card = new Card(reader.GetString(0), reader.GetString(1));
                                getAllCards.Add(card);
                            }
                            return getAllCards;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("something went wrong!");
            }
        }

        public void AddCard(Card card)
        {
            string query = @"INSERT INTO card (card_id, card_title) VALUES (@card_id, @card_title)";
            try
            {
                using (connection)
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@card_id", card.card_id);
                        command.Parameters.AddWithValue("@card_title", card.card_title);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("something went wrong while adding to database! Please try again");
            }

        }

        public Card GetCard(string cardId)
        {
            string query = "SELECT `card_id`, `card_title` FROM `card` WHERE `card_id`= @card_id";
            try
            {
                using (connection)
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@card_id", cardId);
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Card card = new Card(reader.GetString(0), reader.GetString(1));
                                return card;
                            }
                            return null;
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw new Exception("something went wrong! Please try again");
            }
        }

        public void UpdateCard(string card_id, string card_title)
        {
            string query = @"UPDATE `card` SET `card_title`= @card_title WHERE `card_id`= @card_id";
            try
            {
                using (connection)
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@card_id", card_id);
                        command.Parameters.AddWithValue("@card_title", card_title);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("something went wrong while updating the database! Please try again");
            }
        }

        public void DeleteCard(string card_id)
        {
            string query = @"DELETE FROM `card` WHERE `card_id`=@card_id";
            try
            {
                using (connection)
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@card_id", card_id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("something went wrong while deleting the database! Please try again");
            }
        }

    }
}
