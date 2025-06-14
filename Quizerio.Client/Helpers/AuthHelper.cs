using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Quizerio.Client.Helpers
{
    public static class AuthHelper
    {
        public static async Task SetAuthorizationHeaderAsync(HttpClient http, IJSRuntime js)
        {
            var token = await js.InvokeAsync<string>("localStorage.getItem", "authToken");
            if (!string.IsNullOrEmpty(token))
            {
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                http.DefaultRequestHeaders.Authorization = null;
            }
        }

        public static async Task<string> GetUserIdAsync(IJSRuntime js)
        {
            var token = await js.InvokeAsync<string>("localStorage.getItem", "authToken");
            if (!string.IsNullOrEmpty(token))
            {
                var parts = token.Split('.');
                if (parts.Length != 3)
                    return null;

                var payload = parts[1];
                // Pad base64 string if needed
                switch (payload.Length % 4)
                {
                    case 2: payload += "=="; break;
                    case 3: payload += "="; break;
                }
                var jsonBytes = Convert.FromBase64String(payload.Replace('-', '+').Replace('_', '/'));
                var json = System.Text.Encoding.UTF8.GetString(jsonBytes);

                var doc = System.Text.Json.JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("sub", out var userId))
                    return userId.GetString();
            }
            return null;
        }
    }
}