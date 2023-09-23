using LoginApp.Constants;
using LoginApp.MVVM.Models;
using Newtonsoft.Json;

namespace LoginApp.MVVM.Views;

public partial class ProfilePage : ContentPage
{
    private User _userLogged;
    public User UserLogged
    {
        get => _userLogged;
        set
        {
            _userLogged = value;
            OnPropertyChanged(nameof(UserLogged));

            username.Text = UserLogged.FullName;
            email.Text = UserLogged.Email;
        }
    }
    
    public ProfilePage()
    {
        InitializeComponent();
        if (Preferences.ContainsKey(StringConstants.UserLogged))
        {
            var user = Preferences.Get(StringConstants.UserLogged, StringConstants.Anonymous);

            UserLogged = JsonConvert.DeserializeObject<User>(user);
        }        
    }
}