using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _http;
        private readonly IAuthService _authService;

        public OrderService(HttpClient http, IAuthService authService)
        {
            _http = http;
            _authService = authService;
        }

        public async Task<OrderDetailsResponse> GetOrderDetailsAsync(int orderId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<OrderDetailsResponse>>($"api/order/{orderId}");
            return result!.Data!;
        }

        public async Task<List<OrderOverviewResponse>> GetOrdersAsync()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<OrderOverviewResponse>>>("api/order");
            return result!.Data!;
        }

        public async Task<string> PlaceOrderAsync()
        {
            if (await _authService.IsUserAuthenticatedAsync())
            {
                var result = await _http.PostAsync("api/payment/checkout", null);
                var url = await result.Content.ReadAsStringAsync();
                return url;
            }
            else
            {
                return "login";
            }
        }
    }
}
