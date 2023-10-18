namespace BlazorEcommerce.Client.Services.ProductTypeService
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly HttpClient _http;

        public ProductTypeService(HttpClient http)
        {
            _http = http;
        }

        public List<ProductType> ProductTypes { get; set; } = new List<ProductType>();

        public event Action? OnChange;

        public async Task AddProductTypeAsync(ProductType productType)
        {
            var response = await _http.PostAsJsonAsync("api/producttype", productType);
            var content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<ProductType>>>();

            if (content?.Data != null)
                ProductTypes = content.Data;

            OnChange?.Invoke();
        }

        public ProductType CreateNewProductType()
        {
            var newProductType = new ProductType { IsNew = true, Editing = true };

            ProductTypes.Add(newProductType);
            OnChange?.Invoke();
            return newProductType;
        }

        public async Task GetProductTypesAsync()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<ProductType>>>("api/producttype");
            
            if(result?.Data != null)
                ProductTypes = result.Data;
        }

        public async Task UpdateProductTypeAsync(ProductType productType)
        {
            var response = await _http.PutAsJsonAsync("api/producttype", productType);
            var content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<ProductType>>>();

            if(content?.Data != null)
                ProductTypes = content.Data;
            
            OnChange?.Invoke();
        }
    }
}
