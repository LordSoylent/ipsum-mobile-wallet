using ipsum_mobile_wallet.Interfaces;
using ipsum_mobile_wallet.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ipsum_mobile_wallet.ViewModels
{
    public class SignInPageViewModel : BaseViewModel
    {
        private ObservableCollection<User> _accounts;
        private string _login;

        public SignInPageViewModel(ISqlLiteDbAccess sqlLiteDbAccess, INavigationService navigationService)
            : base(sqlLiteDbAccess, navigationService)
        {
        }

        public ObservableCollection<User> Accounts
        {
            get
            {
                return this._accounts;
            }
            set
            {
                SetProperty(ref this._accounts, value);
            }
        }

        public string Login
        {
            get
            {
                return this._login;
            }
            set
            {
                SetProperty(ref this._login, value);
            }
        }

        private void AccountSelected(User user)
        {
            this.Login = user.Name;
        }
    }
}
