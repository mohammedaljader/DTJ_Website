using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTJ_Website.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        private readonly ICardService cardService;

        public CardController(ILogger<CardController> logger)
        {
            _logger = logger;
            cardService = new CardService();
        }

        [HttpGet]
        public IEnumerable<Card> GetAllCards()
        {
            return cardService.GetAllCards();
        }

        [HttpGet("{id}")]
        public Card GetCardById(string id)
        {
            return cardService.GetCardById(id);
        }

        [HttpPost]
        public JsonResult AddCard(Card card)
        {
            bool result = cardService.AddCard(card);
            if(result == false)
            {
                return new JsonResult("Failed to add");
            }
            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult UpdateCard(Card card)
        {
            bool result = cardService.UpdateCard(card.card_id, card.card_title);
            if (result == false)
            {
                return new JsonResult("Failed to update");
            }
            return new JsonResult("updated Successfully");
        }


        [HttpDelete("{id}")]
        public JsonResult DeleteCard(string id)
        {
            bool result = cardService.DeleteCard(id);
            if (result == false)
            {
                return new JsonResult("Failed to delete");
            }
            return new JsonResult("deleted Successfully");
        }
    }
}
