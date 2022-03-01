using pizza.api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pizza.api.Service
{
    public interface IOrderService
    {
        Task<List<Order>> Get();
        Task<Order> GetById(int id);
        Task Add(Order item);
        Task Update(Order item);
        Task Delete(int id);
        Task<bool> OrderExists(int id);
    }
}
