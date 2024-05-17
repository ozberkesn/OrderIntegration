using OrderIntegration.ACompany.Shared.Dtos;
using OrderIntegration.ACompany.Web.Models.Orders;
using OrderIntegration.ACompany.Web.Services.Interfaces;

namespace OrderIntegration.ACompany.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OrderViewModel>> GetWaitingOrders()
        {
            var response = await _httpClient.GetFromJsonAsync<Response<List<OrderViewModel>>>("order");

            return response.Data;
        }

        public async Task<OrderUpdatedViewModel> UpdateOrderStatus(UpdateOrderInput updateOrderInput)
        {
            var response = await _httpClient.PutAsJsonAsync<UpdateOrderInput>("order", updateOrderInput);
            if (!response.IsSuccessStatusCode)
            {
                return new OrderUpdatedViewModel() { Error = "Güncelleme başarısız", IsSuccessful = false };
            }

            return new OrderUpdatedViewModel() { IsSuccessful = true, Id = updateOrderInput.OrderId };
        }
    }
}
