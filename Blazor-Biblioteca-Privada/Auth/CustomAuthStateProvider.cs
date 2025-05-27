using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorApp.Auth
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationState _ano;

        public CustomAuthStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            _ano = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var userId = await _localStorage.GetItemAsync<int>("userId");
            var token = await _localStorage.GetItemAsync<string>("token");

            if (userId == 0 || string.IsNullOrEmpty(token))
            {
                return _ano;
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            };

            var identity = new ClaimsIdentity(claims, "Custom");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }
        public async Task MarkAsAuthenticatedAsync(int userId, string token)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            };
            var identity = new ClaimsIdentity(claims, "Custom");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
        public void MarkUserAsLoggedOut()
        {
            NotifyAuthenticationStateChanged(Task.FromResult(_ano));
        }
    }
} 