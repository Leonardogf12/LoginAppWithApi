namespace LoginApp.MVVM.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}


    private async void ToolbarItemLogout_Clicked(object sender, EventArgs e)
    {
        App.RemoveUserDetailsFromPreferences();
        await Navigation.PopToRootAsync();
    }

    private async void ToolbarItemProfile_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage());
    }
}