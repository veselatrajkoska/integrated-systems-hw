using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MovieTickets.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId)
                .Include("UserShoppingCart.TicketsInShoppingCart")
                .Include("UserShoppingCart.TicketsInShoppingCart.Ticket")
                .FirstOrDefault();

            var userShoppingCart = user.UserShoppingCart;

            var ticketList = userShoppingCart.TicketsInShoppingCart.Select(t => new
            {
                Quantity = t.Quantity,
                TicketPrice = t.Ticket.ticketPrice
            });

            int totalPrice = 0;
            foreach (var ticket in ticketList)
            {
                totalPrice += ticket.TicketPrice * ticket.Quantity;
            }

            ShoppingCartDto model = new ShoppingCartDto
            {
                TotalPrice = totalPrice,
                TicketsInShoppingCart = userShoppingCart.TicketsInShoppingCart.ToList()
            };

            return View();
        }

        public IActionResult DeleteFromShoppingCart(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId)
                .Include("UserShoppingCart.TicketsInShoppingCart")
                .Include("UserShoppingCart.TicketsInShoppingCart.Ticket")
                .FirstOrDefault();

            var userShoppingCart = user.UserShoppingCart;
            var forRemoval = userShoppingCart.TicketsInShoppingCart.Where(t => t.TicketId == id).FirstOrDefault();
            userShoppingCart.TicketsInShoppingCart.Remove(forRemoval);
            _context.Update(userShoppingCart);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult BuyNow()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId)
                .Include("UserShoppingCart.TicketsInShoppingCart")
                .Include("UserShoppingCart.TicketsInShoppingCart.Ticket")
                .FirstOrDefault();

            var userShoppingCart = user.UserShoppingCart;

            Order newOrder = new Order
            {
                UserId = user.Id,
                OrderedBy = user,
            };

            _context.Add(newOrder);
            _context.SaveChanges();

            List<TicketInOrder> ticketsInOrder = userShoppingCart.TicketsInShoppingCart.Select(t => new TicketInOrder
            {
                Ticket = t.Ticket,
                TicketId = t.TicketId,
                Order = newOrder,
                OrderId = newOrder.OrderId
            }).ToList();

            foreach(var item in ticketsInOrder)
            {
                _context.Add(item);
            }

            user.UserShoppingCart.TicketsInShoppingCart.Clear();
            _context.Update(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
