using LoginApp.MVVM.Views;
using LoginApp.Services.UserService;

namespace LoginApp.MVVM.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public readonly IUserService _userService;


        #region Properts

        private string _entryEmail;
        public string EntryEmail
        {
            get => _entryEmail;
            set => SetProperty(ref _entryEmail, value);
        }


        private string _entryPassword;
        public string EntryPassword
        {
            get => _entryPassword;
            set => SetProperty(ref _entryPassword, value);
        }

        #endregion


        public Command LoginCommand { get; set; }


        public LoginViewModel()
        {
            _userService = new UserService();

            LoginCommand = new Command(async () => OnLoginCommand());
        }

        private async Task OnLoginCommand()
        {
            IsBusy = true;
            
            try
            {
                if (!(String.IsNullOrEmpty(EntryEmail) && String.IsNullOrEmpty(EntryPassword)))
                {
                    var user = await _userService.Login(EntryEmail, EntryPassword);

                    if (user == null)
                    {
                        IsBusy = false;
                        await App.Current.MainPage.DisplayAlert("Login", "Ocorreu um erro inesperado.", "OK");
                        return;
                    }

                    App.RemoveUserDetailsFromPreferences();
                    App.AddUserDetailsOnPreferences(user);

                    await App.Current.MainPage.Navigation.PushAsync(new HomePage());

                }

                return;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", $"Ocorreu um erro inesperado. Detalhes: {ex.Message}", "OK");
                Console.WriteLine(ex.ToString());
            }
            finally
            {             
                IsBusy = false;
            }
        }
    }
}
