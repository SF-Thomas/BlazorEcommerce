﻿namespace BlazorEcommerce.Client.Services.ProductTypeService
{
    public interface IProductTypeService
    {
        event Action OnChange;
        public List<ProductType> ProductTypes { get; set; }
        Task GetProductTypesAsync();
        Task AddProductTypeAsync(ProductType productType);
        Task UpdateProductTypeAsync(ProductType productType);
        ProductType CreateNewProductType();
    }
}
