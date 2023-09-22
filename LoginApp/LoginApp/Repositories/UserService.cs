using LoginApp.Constants;
using LoginApp.MVVM.Models;
using Newtonsoft.Json;

namespace LoginApp.Repositories
{
    public class UserService : IUserRepository
    {
        public async Task<User> Login(string email, string password)
        {
            var client = new HttpClient();

            //var url = StringConstants.UrlApi + $"{email}/{password}";
            var url = $"http://192.168.15.65:8181/api/User/login/{email}/{password}";
            //https://localhost:7136/api/User/login/leo%40leo.com/123456'

            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                User user = JsonConvert.DeserializeObject<User>(content);

                return await Task.FromResult(user);
            }

            return null!;
        }
    }
}
