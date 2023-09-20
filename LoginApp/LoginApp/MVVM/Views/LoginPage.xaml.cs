namespace LoginApp.MVVM.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void LoginClicked(object sender, EventArgs e)
    {
		if(!(String.IsNullOrEmpty(EntryEmail.Text) 
			&& String.IsNullOrEmpty(EntryPassword.Text)))
		{
            //TODO Create validation and request API.
            
        }
    }
}