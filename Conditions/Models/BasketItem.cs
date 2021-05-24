using System;
using System.Collections.Generic;
using System.Text;

namespace Conditions.Models
{
    class BasketItem
    {
        public int Quantity { get; set; }
        public TicketModel ticketModel { get; set; }
    }
}
