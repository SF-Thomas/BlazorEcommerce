﻿namespace BlazorEcommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Category> AdminCategories { get; set; } = new List<Category>();

        public event Action? OnChange;

        public async Task AddCategoryAsync(Category category)
        {
            var response = await _http.PostAsJsonAsync("api/Category/admin", category);
            var content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Category>>>();
            AdminCategories = content!.Data!;
            await GetCategoriesAsync();
            OnChange?.Invoke();
        }

        public Category CreateNewCategory()
        {
            var newCategory = new Category { IsNew = true, Editing = true };
            AdminCategories.Add(newCategory);
            OnChange?.Invoke();
            return newCategory;
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var response = await _http.DeleteAsync($"api/Category/admin/{categoryId}");
            var content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Category>>>();
            AdminCategories = content!.Data!;
            await GetCategoriesAsync();
            OnChange?.Invoke();
        }

        public async Task GetAdminCategoriesAsync()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category/admin");
            if (response != null && response.Data != null)
                AdminCategories = response.Data;
        }

        public async Task GetCategoriesAsync()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
            if (response != null && response.Data != null)
                Categories = response.Data;
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var response = await _http.PutAsJsonAsync("api/Category/admin", category);
            var content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Category>>>();

            if (content is null || content.Data == null)
                return;

            AdminCategories = content.Data;
            await GetCategoriesAsync();
            OnChange?.Invoke();
        }
    }
}
