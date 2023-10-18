namespace BlazorEcommerce.Client.Services.OrderService
{
    public interface IOrderService
    {
        Task<string> PlaceOrderAsync();
        Task<List<OrderOverviewResponse>> GetOrdersAsync();
        Task<OrderDetailsResponse> GetOrderDetailsAsync(int orderId);
    }
}
