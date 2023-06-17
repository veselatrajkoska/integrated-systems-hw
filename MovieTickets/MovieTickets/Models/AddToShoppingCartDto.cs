namespace MovieTickets.Models
{
    public class AddToShoppingCartDto
    {
        public Ticket ticket { get; set; }
        public int TicketId { get; set; }
        public int Quantity { get; set; }
    }
}
