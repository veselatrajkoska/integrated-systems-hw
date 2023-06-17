using System.Collections.Generic;

namespace MovieTickets.Models
{
    public class ShoppingCartDto
    {
        public List<TicketsInShoppingCart> TicketsInShoppingCart { get; set; }
        public int TotalPrice { get; set; }
    }
}
