using LoginApp.MVVM.ViewModels;

namespace LoginApp.MVVM.Views;

public partial class LoginPage : ContentPage
{
    public LoginViewModel model = new();

    public LoginPage()
    {        
        InitializeComponent();

        BindingContext = model;
    }
   
}