using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTickets.Data
{
    public class ApplicationDbContext : IdentityDbContext<TicketsApplicationUser>
    {
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<TicketsInShoppingCart> TicketsInShoppingCart { get; set; }
        public virtual DbSet<TicketsApplicationUser> TicketsApplicationUsers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<TicketInOrder> TicketsInOrder { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TicketsInShoppingCart>().HasKey(t => new { t.CartId, t.TicketId });
            builder.Entity<TicketInOrder>().HasKey(t => new { t.OrderId, t.TicketId });
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
