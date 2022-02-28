using System;

namespace pizza.api.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string CustomerName { get; set; }
    }
}
