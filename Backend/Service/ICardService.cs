using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICardService
    {
        List<Card> GetAllCards();

        Card GetCardById(string card_id);

        bool AddCard(Card card);

        bool UpdateCard(string card_id, string card_title);

        bool DeleteCard(string card_id);
    }
}
