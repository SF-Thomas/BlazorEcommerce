namespace BlazorEcommerce.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider)
        {
            _http = http;
            _authStateProvider = authStateProvider;
        }

        public async Task<ServiceResponse<bool>> ChangePasswordAsync(UserChangePassword request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/change-password", request.Password);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            return content!;
        }

        public async Task<bool> IsUserAuthenticatedAsync()
        {
            var state = await _authStateProvider.GetAuthenticationStateAsync();

            if (state is null || state.User.Identity is null)
                return false;

            return state.User.Identity.IsAuthenticated;
        }

        public async Task<ServiceResponse<string>> LoginAsync(UserLogin request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/login", request);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
            return content!;
        }

        public async Task<ServiceResponse<int>> RegisterAsync(UserRegister request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/register", request);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();

            return content!;
        }
    }
}
