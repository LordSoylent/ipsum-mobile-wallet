using ipsum_mobile_wallet.Interfaces;
using ipsum_mobile_wallet.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ipsum_mobile_wallet.ViewModels
{
    public class MainPageViewModel : BaseViewModel, INavigatedAware
    {
        private readonly ISqlLiteDbAccess _sqlLiteDbAccess;
        private readonly INavigationService _navigationService;

        public MainPageViewModel(ISqlLiteDbAccess sqlLiteDbAccess, INavigationService navigationService)
            : base(sqlLiteDbAccess, navigationService)
        {
            this._sqlLiteDbAccess = sqlLiteDbAccess;
            this._navigationService = navigationService;
            this.SignInCommand = new DelegateCommand(SignIn);
            this.CreateProfileCommand = new DelegateCommand(CreateProfile);
        }

        public DelegateCommand SignInCommand { get; set; }
        public DelegateCommand CreateProfileCommand { get; set; }

        private async void CreateProfile()
        {
            await this._navigationService.NavigateAsync("CreateProfilePage");
        }

        private async void SignIn()
        {
            await this._navigationService.NavigateAsync("SignInPage");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
