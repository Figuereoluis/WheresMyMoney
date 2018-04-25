namespace WhereIsMyMoney.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Services;
    using Views;
    using Xamarin.Forms;
    using Helpers;
    using WhereIsMyMoney.Models;
    using WhereIsMyMoney.Domain;

    public class LoginViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private readonly ApiService _apiService;
        private readonly DialogService _dialogService;
        private readonly DataService _dataService;
        private readonly NavigationService _navigationService;
        private string _email;
        private string _password;
        private bool _isRunning;
        private bool _isEnabled;
        private bool _isRemembered;
        #endregion

        #region Properties
        public string Email
        {
            get { return this._email; }
            set { SetValue(ref this._email, value); }
        }

        public string Password
        {
            get { return this._password; }
            set { SetValue(ref this._password, value); }
        }

        public bool IsRunning
        {
            get { return this._isRunning; }
            set { SetValue(ref this._isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this._isEnabled; }
            set { SetValue(ref this._isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.apiService = new ApiService();

            this.IsRemembered = true;
            this.IsEnabled = true;

            this.Email = "sgermosen@outlook.com";
            this.Password = "123456";
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PasswordValidation,
                    Languages.Accept);
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    connection.Message,
                    Languages.Accept);
                return;
            }
            var parameters = _dataService.First<Parameter>(false);
            var token = await this.apiService.GetToken(
                parameters.UrlBase,
                this.Email,
                this.Password);

            if (token == null)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.SomethingWrong,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(token.AccessToken))
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    token.ErrorDescription,
                    Languages.Accept);
                this.Password = string.Empty;
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token;
            //mainViewModel.Lands = new LandsViewModel();
            var response = await _apiService.GetUserByEmail(parameters.UrlBase,
               "/api", "/Users/GetUserByEmail", token.TokenType, token.AccessToken, token.UserName);

            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await _dialogService.ShowMessage("Error", "Problem ocurred retrieving user information, try latter.");
                return;
            }

            var user = (User)response.Result;

            user.AccessToken = token.AccessToken;
            user.TokenType = token.TokenType;
            user.TokenExpires = token.Expires;
            user.IsRemembered = IsRemembered;
            user.Password = Password;
            //_dataService.DeleteAllAndInsert(user.FavoriteTeam);
            _dataService.DeleteAllAndInsert(user.UserType);
            _dataService.DeleteAllAndInsert(user);

            //if (!response.IsSuccess)
            //{
            //    IsRunning = false;
            //    IsEnabled = true;
            //    await _dialogService.ShowMessage("Error", "Problem ocurred retrieving user information, try latter.");
            //    return;
            //}
           // var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.CurrentUser = user;
            mainViewModel.SetCurrentUser(user);
            Email = null;
            // Password = null;
            Password = null;

            IsRunning = false;
            IsEnabled = true;
            mainViewModel.RegisterDevice(); //todo
            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;
            _navigationService.SetMainPage("MasterPage");
            await Application.Current.MainPage.Navigation.PushAsync(new MasterPage());

           
        }
        #endregion
    }
}
