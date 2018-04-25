
namespace WhereIsMyMoney.ViewModels
{
    using System.Collections.Generic;
   using Models;
    using WhereIsMyMoney.Domain;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Plugin.Connectivity;
    using Interfaces;
    using Services;
    using Xamarin.Forms;

    public class MainViewModel : BaseViewModel
    {
        #region Atriutos
        private readonly ApiService _apiService;
        private readonly DataService _dataService;

        private User _currentUser;
        #endregion

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        //public ChangePasswordViewModel ChangePassword { get; set; }
        //public ForgotPasswordViewModel ForgotPassword { get; set; }
        //public NewUserViewModel NewUser { get; set; }
        //public ProfileViewModel Profile { get; set; }
       
        //public List<Land> LandsList
        //{
        //    get;
        //    set;
        //}

        public TokenResponse Token
        {
            get;
            set;
        }
        public User CurrentUser
        {
            get { return this._currentUser; }
            set { SetValue(ref this._currentUser, value); }
        }
        //public User CurrentUser
        //{
        //    set {
        //        if (_currentUser == value) return;
        //        _currentUser = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentUser"));
        //    }
        //    get {
        //        return _currentUser;
        //    }
        //}
        #endregion

        #region ViewModels
        public LoginViewModel Login { get; set; }

        //public LandsViewModel Lands
        //{
        //    get;
        //    set;
        //}

        //public LandViewModel Land
        //{
        //    get;
        //    set;
        //}
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion

        #region Metodos
        public void RegisterDevice()
        {
            var register = DependencyService.Get<IRegisterDevice>();
            register.RegisterDevice();
        }

        public void SetCurrentUser(User user)
        {
            CurrentUser = user;
        }

        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            //Menu.Add(new MenuItemViewModel
            //{
            //    Icon = "predictions.png",
            //    PageName = "SelectTournamentPage",
            //    Title = "Predictions",
            //});

            //Menu.Add(new MenuItemViewModel
            //{
            //    Icon = "groups.png",
            //    PageName = "SelectUserGroupPage",
            //    Title = "Groups",
            //});

            //Menu.Add(new MenuItemViewModel
            //{
            //    Icon = "tournaments.png",
            //    PageName = "SelectTournamentPage",
            //    Title = "Tournaments",
            //});

            //Menu.Add(new MenuItemViewModel
            //{
            //    Icon = "myresults.png",
            //    PageName = "SelectTournamentPage",
            //    Title = "My Results",
            //});

            //Menu.Add(new MenuItemViewModel
            //{
            //    Icon = "config.png",
            //    PageName = "ConfigPage",
            //    Title = "Config",
            //});

            //Menu.Add(new MenuItemViewModel
            //{
            //    Icon = "logut.png",
            //    PageName = "LoginPage",
            //    Title = "Logut",
            //});
        }


        #endregion
    }
}
