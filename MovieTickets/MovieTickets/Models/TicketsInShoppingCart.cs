using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTickets.Models
{
    public class TicketsInShoppingCart
    {
        public int TicketId { get; set; }
        public int CartId { get; set; }
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
        [ForeignKey("CartId")]
        public ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }

    }
}
