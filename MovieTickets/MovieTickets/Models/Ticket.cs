using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [Required]
        [Display(Name = "Movie")]
        public string movie { get; set; }
        [Display(Name = "Image")]
        public string movieImage { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Price")]
        public int ticketPrice { get; set; }
        [Display(Name = "Date and Time")]
        public DateTime dateTime { get; set; }
        public ICollection<TicketsInShoppingCart> TicketsInShoppingCart { get; set; }
    }
}
