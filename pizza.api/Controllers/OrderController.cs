using Microsoft.AspNetCore.Mvc;
using pizza.api.Models;
using pizza.api.Service;
using System.Linq;

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
        public IActionResult get()
        {
            var model = service.Get();

            return Ok(model);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult getbyid([FromQuery]int id)
        {
            var model = service.GetById(id);
            if (model == null)
                return NotFound();

            return Ok(model);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult create([FromBody] OrderRequest inputModel)
        {
            if (inputModel == null)
                return BadRequest();

            Order order = inputModel.Adapt(inputModel);

            order.Id = service.Get().Max(_ => _.Id) + 1;
            service.Add(order);

            return Ok(inputModel);
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult update([FromBody] Order inputModel)
        {
            if (inputModel == null)
                return BadRequest();
            if (!service.OrderExists(inputModel.Id))
                return NotFound();

            service.Update(inputModel);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult delete(int id)
        {
            if (!service.OrderExists(id))
                return NotFound();
            service.Delete(id);
            return Ok();
        }

    }
}
