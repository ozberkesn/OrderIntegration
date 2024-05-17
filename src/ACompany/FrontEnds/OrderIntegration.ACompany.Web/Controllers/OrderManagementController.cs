using Microsoft.AspNetCore.Mvc;
using OrderIntegration.ACompany.Web.Services.Interfaces;

namespace OrderIntegration.ACompany.Web.Controllers
{
    public class OrderManagementController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderManagementController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {            
            return View(await _orderService.GetWaitingOrders());
        }

        [HttpGet]
        public async Task<IActionResult> Delivered(int id)
        {
            var result = await _orderService.UpdateOrderStatus(new Models.Orders.UpdateOrderInput { OrderId = id, StatusId = 1 });
            return Ok(result);
        }
    }
}
