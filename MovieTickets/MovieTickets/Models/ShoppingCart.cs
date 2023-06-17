using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }
        public string UserId { get; set; }
        public ICollection<TicketsInShoppingCart> TicketsInShoppingCart { get; set; }
    }
}
