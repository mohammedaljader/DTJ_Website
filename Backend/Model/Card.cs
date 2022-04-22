using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Card
    {
        public string card_id { get; set; }
        public string card_title { get; set; }

        public Card(string card_id, string card_title)
        {
            this.card_id = card_id;
            this.card_title = card_title;
        }
    }
}
