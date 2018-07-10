using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiSample.DataAccess.Models;

namespace WebApiSample.DataAccess.Repositories
{
    public class OrdersRepository
    {
        private readonly OrderContext _context;

        public OrdersRepository(OrderContext context)
        {
            _context = context;

            if (_context.Orders.Count() == 0)
            {
                _context.Orders.AddRange(
                    new Order
                    {
                        OrderDate = DateTime.Now,
                        Description = "Textbook order for John Doe"
                    },
                    new Order
                    {
                        OrderDate = DateTime.Now,
                        Description = "Docs laptop sticker order for Jane Doe"
                    });
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<int> AddOrderAsync(Order order)
        {
            int rowsAffected = 0;

            _context.Orders.Add(order);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }
    }
}
