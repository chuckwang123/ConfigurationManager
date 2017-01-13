using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ConfigurationManager.Interfaces;
using Microsoft.Extensions.Options;

namespace ConfigurationManager.Models
{
    public class IPLValidator : IIPLValidator
    {
        public async Task ValidateIPLAuthentication(IPLAuth auth, IOptions<IPLAuth> appSettings)
        {
            using (var client = new HttpClient())
            {
                var authentication = auth.ApiKey + ":" + auth.ApiSecret;
                var authBytes = Encoding.UTF8.GetBytes(authentication);
                authentication = Convert.ToBase64String(authBytes);

                client.BaseAddress = new Uri(appSettings.Value.ApiKey);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authentication);
                var iplRequest = new
                {
                    Problems = new [] { new { FreeText = "Heart Attack" } }
                };

                var response = await client.PostAsJsonAsync("api/v3/actions/categorize", iplRequest);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
