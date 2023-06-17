using Microsoft.AspNetCore.Identity;

namespace MovieTickets.Models
{
    public class TicketsApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }

        public virtual ShoppingCart UserShoppingCart { get; set; }

    }
}
