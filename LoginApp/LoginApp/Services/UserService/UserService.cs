using LoginApp.Constants;
using LoginApp.MVVM.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LoginApp.Services.UserService
{
    public class UserService : IUserService
    {
        public async Task<User> Login(string email, string password)
        {
            try
            {
                var client = new HttpClient();

                var url = $"{StringConstants.UrlApi}Auth/{email}/{password}";

                client.BaseAddress = new Uri(url);

                var token = await SecureStorage.GetAsync(StringConstants.AuthToken);
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(StringConstants.Bearer, token);
                }

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    User user = JsonConvert.DeserializeObject<User>(content);

                    _ = SecureStorage.SetAsync(StringConstants.AuthToken, user.Token);

                    return await Task.FromResult(user);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return null;
            }
        }
    }
}
