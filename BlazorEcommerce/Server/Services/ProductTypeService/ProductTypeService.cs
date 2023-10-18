namespace BlazorEcommerce.Server.Services.ProductTypeService
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly DataContext _context;

        public ProductTypeService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ProductType>>> AddProductTypeAsync(ProductType productType)
        {
            productType.Editing = productType.IsNew = false;
            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();

            return await GetProductTypesAsync();
        }

        public async Task<ServiceResponse<List<ProductType>>> GetProductTypesAsync()
        {
            var productTypes = await _context.ProductTypes.ToListAsync();
            return new ServiceResponse<List<ProductType>> { Data = productTypes };
        }

        public async Task<ServiceResponse<List<ProductType>>> UpdateProductTypeAsync(ProductType productType)
        {
            var dbProductType = await _context.ProductTypes.FindAsync(productType.Id);
            if (dbProductType == null)
            {
                return new ServiceResponse<List<ProductType>>
                {
                    Success = false,
                    Message = "Product Type not found."
                };
            }

            dbProductType.Name = productType.Name;
            await _context.SaveChangesAsync();

            return await GetProductTypesAsync();
        }
    }
}
