using LoginApp.Repositories;
using LoginApp.MVVM.Models;
using Newtonsoft.Json;

namespace LoginApp.MVVM.Views;

public partial class LoginPage : ContentPage
{
    readonly IUserRepository _userRepository = new UserService();

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void LoginClicked(object sender, EventArgs e)
    {
        try
        {

            if (Preferences.ContainsKey(nameof(App.UserDetails)))
            {
                await App.Current.MainPage.Navigation.PushAsync(new MainPage());
                return;
            }
                            

            if (!(String.IsNullOrEmpty(EntryEmail.Text) && String.IsNullOrEmpty(EntryPassword.Text)))
            {
                var user = await _userRepository.Login(EntryEmail.Text, EntryPassword.Text);

                if (user == null)
                {
                    await DisplayAlert("Login", "Usuario ou senha invalido", "OK");
                    return;
                }

                App.RemoveUserDetailsFromPreferences();
                App.AddUserDetailsOnPreferences(user);

                await App.Current.MainPage.Navigation.PushAsync(new MainPage());

            }

            return;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Ocorreu um erro inesperado. Detalhes: {ex.Message}", "OK");
            Console.WriteLine(ex.ToString());
        }

    }

    //private void RemoveUserDetailsFromPreferences()
    //{
    //    if (Preferences.ContainsKey(nameof(App.UserDetails)))
    //    {
    //        Preferences.Remove(nameof(App.UserDetails));
    //    }
    //}

    //private void AddUserDetailsOnPreferences(object obj)
    //{
    //    string userDetails = JsonConvert.SerializeObject(obj);
    //    Preferences.Set(nameof(App.UserDetails), userDetails);
    //}
}