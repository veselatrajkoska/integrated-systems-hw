using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public TicketsApplicationUser OrderedBy { get; set; }
        public List<TicketInOrder> TicketsInOrder { get; set; }
    }
}
