using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CardService : ICardService
    {
        private readonly Database db;

        public CardService()
        {
            this.db = new Database();
        }

        public bool AddCard(Card card)
        {
            db.AddCard(card);
            return true;
        }

        public bool DeleteCard(string card_id)
        {
            db.DeleteCard(card_id);
            return true;
        }

        public List<Card> GetAllCards()
        {
            return db.GetAllCards();
        }

        public Card GetCardById(string card_id)
        {
            return db.GetCard(card_id);
        }

        public bool UpdateCard(string card_id, string card_title)
        {
            db.UpdateCard(card_id, card_title);
            return true;
        }
    }
}
