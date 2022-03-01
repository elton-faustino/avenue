using pizza.api.Models;
using System.Collections.Generic;
using System.Linq;

namespace pizza.api.Service
{
    public class OrderService : IOrderService
    {

        private readonly List<Order> orders;

        public OrderService()
        {
            if (orders == null)
            {
                this.orders = new List<Order>()
                {
                    new Order() { Id = 1, Description = "Neapolitan", Date = System.DateTime.Now, CustomerName = "Elton"},
                    new Order() { Id = 2, Description = "Sicilian",  Date = System.DateTime.Now.AddDays(-1), CustomerName = "Mayra" },
                    new Order() { Id = 3, Description = "Greek",  Date = System.DateTime.Now.AddDays(-1), CustomerName = "Corey" }
                };
            }
        }

        public void Add(Order item)
        {
            this.orders.Add(item);
        }

        public void Delete(int id)
        {
            var model = this.orders.Where(m => m.Id == id).FirstOrDefault();
            this.orders.Remove(model);
        }

        public List<Order> Get()
        {
            return this.orders.ToList();
        }

        public Order GetById(int id)
        {
            return this.orders.Where(m => m.Id == id).FirstOrDefault();
        }

        public bool OrderExists(int id)
        {
            return this.orders.Any(m => m.Id == id);
        }

        public void Update(Order item)
        {
            var model = this.orders.Where(m => m.Id == item.Id).FirstOrDefault();

            model.Description = item.Description;
            model.Date = item.Date;
            model.CustomerName = item.CustomerName;
        }
    }
}
