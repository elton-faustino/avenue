using pizza.api.Models;
using System.Collections.Generic;

namespace pizza.api.Service
{
    public interface IOrderService
    {
        List<Order> Get();
        Order GetById(int id);
        void AddFilme(Order item);
        void Update(Order item);
        void Delete(int id);
        bool OrderExists(int id);
    }
}
