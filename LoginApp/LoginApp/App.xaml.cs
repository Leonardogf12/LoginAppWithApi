using LoginApp.Constants;
using LoginApp.MVVM.Models;
using LoginApp.MVVM.Views;
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

            InitializeApp();
        }

        private async void InitializeApp()
        {
            if (Preferences.ContainsKey(StringConstants.UserLogged))
            {
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
                return;
            }
        }

        public static void RemoveUserDetailsFromPreferences()
        {
            if (Preferences.ContainsKey(StringConstants.UserLogged))
            {
                Preferences.Remove(StringConstants.UserLogged);
            }
        }

        public static void AddUserDetailsOnPreferences(object obj)
        {
            string userDetails = JsonConvert.SerializeObject(obj);

            Preferences.Set(StringConstants.UserLogged, userDetails);
        }
    }
}