using StoryWriter.PageModels.Base;
using StoryWriter.Services;
using StoryWriter.ViewModels;
using StoryWriter.ViewModels.Buttons;

namespace StoryWriter.PageModels
{
    public class LoginPageModel : PageModelBase
    {
        private string _icon;

        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public LoginEntryViewModel EmailEntryViewModel { get; set; }
        public LoginEntryViewModel PasswordEntryViewModel { get; set; }

        public ButtonModel ForgotPasswordModel { get; set; }
        public ButtonModel LogInModel { get; set; }
        public ButtonModel UsePhoneModel { get; set; }

        public ButtonModel UseAnonymous { get; set; }

        private IAccountService _accountService;
        private readonly IMessageService messageService;
        private INavigationService _navigationService;

        public LoginPageModel(INavigationService navigationService,
            IAccountService accountService, IMessageService messageService)
        {
            _accountService = accountService;
            this.messageService = messageService;
            _navigationService = navigationService;

            EmailEntryViewModel = new LoginEntryViewModel("email", false);
            PasswordEntryViewModel = new LoginEntryViewModel("password", true);

            ForgotPasswordModel = new ButtonModel("forgot password", OnForgotPassword);
            LogInModel = new ButtonModel("LOG IN", OnLogin);
            UsePhoneModel = new ButtonModel("USE PHONE NUMBER", GoToPhoneLogin);
            UseAnonymous = new ButtonModel("Anonymous login", OnLoginAnonymous);
        }

        private async void OnLoginAnonymous()
        {
            var loginAttempt = await _accountService.LoginAnonymous();
            if (loginAttempt)
            {
                await _navigationService.NavigateToAsync<StoriesPageModel>(null, true);
            }
            else
            {
                messageService.LongAlert("Login failed");
            }
        }

        private async void OnLogin()
        {
            var loginAttempt = await _accountService.LoginAsync(EmailEntryViewModel.Text, PasswordEntryViewModel.Text);
            if (loginAttempt)
            {
                // navigate to the Dashboard.
                await _navigationService.NavigateToAsync<StoriesPageModel>(null, true);
            }
            else
            {
                messageService.LongAlert("Login failed");
            }
        }

        private void OnForgotPassword()
        {
        }

        private void GoToPhoneLogin()
        {
            _navigationService.NavigateToAsync<LoginPhonePageModel>();
        }
    }
}