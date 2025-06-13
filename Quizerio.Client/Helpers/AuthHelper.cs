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
    }
}