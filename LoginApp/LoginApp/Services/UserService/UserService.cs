using LoginApp.Constants;
using LoginApp.MVVM.Models;
using Newtonsoft.Json;

namespace LoginApp.Services.UserService
{
    public class UserService : IUserService
    {
        public async Task<User> Login(string email, string password)
        {

            try
            {
                var client = new HttpClient();

                var url = $"{StringConstants.UrlApi}{email}/{password}";

                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    User user = JsonConvert.DeserializeObject<User>(content);

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
