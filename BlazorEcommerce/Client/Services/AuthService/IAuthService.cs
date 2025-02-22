﻿namespace BlazorEcommerce.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> RegisterAsync(UserRegister request);
        Task<ServiceResponse<string>> LoginAsync(UserLogin request);
        Task<ServiceResponse<bool>> ChangePasswordAsync(UserChangePassword request);
        Task<bool> IsUserAuthenticatedAsync();
    }
}
