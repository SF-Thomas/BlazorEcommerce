namespace BlazorEcommerce.Client.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _http;

        public AddressService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Address> AddOrUpdateAddressAsync(Address address)
        {
            var response = await _http.PostAsJsonAsync("api/address", address);
            var content = response.Content.ReadFromJsonAsync<ServiceResponse<Address>>();
            return content!.Result!.Data!;
        }

        public async Task<Address> GetAddressAsync()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<Address>>("api/address");
            return response!.Data!;
        }
    }
}
