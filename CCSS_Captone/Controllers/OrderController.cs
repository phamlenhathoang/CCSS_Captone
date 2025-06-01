using CCSS_Repository.Entities;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using CCSS_Service.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CCSS_Captone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderResponse>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }
        [HttpGet("GetAllOrdersByAccountId/{id}")]
        public async Task<ActionResult<List<OrderResponse>>> GetAllOrdersByAccountId(string id)
        {
            var orders = await _orderService.GetAllOrdersByAccountId(id);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetOrderById(string id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] OrderRequest orderRequest)
        {
            var result = await _orderService.CreateOrder(orderRequest);
           
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder([FromRoute] string id, [FromBody] OrderRequest orderRequest)
        {
            var result = await _orderService.UpdateOrder(id, orderRequest);
            if (!result)
                return BadRequest("Failed to update order");
            return Ok("Order updated successfully");
        }

        [HttpPatch("{id}/shipstatus")]
        [SwaggerOperation(Description = "ShipStatus<br>" +
                                         "0 (WaitConfirm)<br>" +
                                         "1 (WaitToPick)<br>" +
                                         "2 (InTransit)<br>" +
                                         "3 (Received)<br>" +
                                         "4 (Cancel)<br>    " +
                                         "5 (Refund)")]
        public async Task<IActionResult> UpdateShipStatus(string id, ShipStatus ShipStatus, string? CancelReason)
        {
            if (ShipStatus == null )
                return BadRequest("ShipStatus is required");

            var result = await _orderService.UpdateOrderStatus(id, ShipStatus, CancelReason);

            if (!result)
                return NotFound();

            return Ok("ok");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(string id)
        {
            var result = await _orderService.DeleteOrder(id);
            if (!result)
                return NotFound("Order not found");
            return Ok("Order deleted successfully");
        }
    }
}
