﻿namespace BlazorEcommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
        Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl);
        Task<ServiceResponse<ProductSearchResult>> SearchProductsAsync(string searchText, int page);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestionsAsync(string searchText);
        Task<ServiceResponse<List<Product>>> GetFeaturedProductsAsync();
        Task<ServiceResponse<List<Product>>> GetAdminProductsAsync();
        Task<ServiceResponse<Product>> CreateProductAsync(Product product);
        Task<ServiceResponse<Product>> UpdateProductAsync(Product product);
        Task<ServiceResponse<bool>> DeleteProductAsync(int productId);
    }
}
