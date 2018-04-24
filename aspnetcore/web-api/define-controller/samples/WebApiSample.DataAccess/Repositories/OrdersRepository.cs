using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public bool TryGetOrder(int id, out Order order)
        {
            order = _context.Orders.Find(id);

            return (order != null);
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
