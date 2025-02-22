﻿namespace BlazorEcommerce.Server.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<List<Category>>> GetCategoriesAsync();
        Task<ServiceResponse<List<Category>>> GetAdminCategoriesAsync();
        Task<ServiceResponse<List<Category>>> AddCategoryAsync(Category category);
        Task<ServiceResponse<List<Category>>> UpdateCategoryAsync(Category category);
        Task<ServiceResponse<List<Category>>> DeleteCategoryAsync(int id);
    }
}
