namespace LoginApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            App.RemoveUserDetailsFromPreferences();
            await Navigation.PopToRootAsync();
        }
    }
}