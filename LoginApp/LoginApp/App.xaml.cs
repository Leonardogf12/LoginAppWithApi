using LoginApp.MVVM.Models;
using Newtonsoft.Json;

namespace LoginApp
{
    public partial class App : Application
    {
        public static User UserDetails;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        public static void RemoveUserDetailsFromPreferences()
        {
            if (Preferences.ContainsKey(nameof(App.UserDetails)))
            {
                Preferences.Remove(nameof(App.UserDetails));
            }
        }

        public static void AddUserDetailsOnPreferences(object obj)
        {
            string userDetails = JsonConvert.SerializeObject(obj);
            Preferences.Set(nameof(App.UserDetails), userDetails);
        }
    }
}