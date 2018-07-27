using ipsum_mobile_wallet.Interfaces;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipsum_mobile_wallet.ViewModels
{
    public abstract class BaseViewModel : BindableBase
    {
        private readonly ISqlLiteDbAccess _dbAccess;
        private readonly INavigationService _navigationService;
        private bool _isBusy;

        public BaseViewModel(ISqlLiteDbAccess sqlLiteDbAccess, INavigationService navigationService)
        {
            this._dbAccess = sqlLiteDbAccess;
            this._navigationService = navigationService;
        }

        public bool IsBusy
        {
            get
            {
                return this._isBusy;
            }
            set
            {
                SetProperty(ref this._isBusy, value);
            }
        }
    }
}
