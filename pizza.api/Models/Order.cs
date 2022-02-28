using System;

namespace pizza.api.Models
{
    public class OrderRequest
    {
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string CustomerName { get; set; }

        internal Order Adapt(OrderRequest inputModel)
        {
            return new Order()
            {
                Description = inputModel.Description,
                Date = inputModel.Date,
                CustomerName = inputModel.CustomerName
            };
        }
    }

    public class Order
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string CustomerName { get; set; }
    }
}
