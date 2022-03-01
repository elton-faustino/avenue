using Microsoft.AspNetCore.Mvc;
using pizza.api.Models;
using pizza.api.Service;
using System.Linq;
using System.Threading.Tasks;

namespace pizza.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService service;

        public OrderController(IOrderService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get()
        {
            var model = await service.Get();

            return Ok(model);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            var model = await service.GetById(id);
            if (model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create([FromBody] OrderRequest inputModel)
        {
            if (inputModel == null)
                return BadRequest();

            var order = inputModel.Adapt(inputModel);

            var fullList = await service.Get();

            order.Id = fullList.Max(_ => _.Id) + 1;
            
            await service.Add(order);

            return Ok(inputModel);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] Order inputModel)
        {
            if (inputModel == null)
                return BadRequest();
            
            if (!service.OrderExists(inputModel.Id).Result)
                return NotFound();

            await service.Update(inputModel);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!service.OrderExists(id).Result)
                return NotFound();

            await service.Delete(id);

            return Ok();
        }

    }
}
