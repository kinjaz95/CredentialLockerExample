using CredentialLockerExample.Models;
using CredentialLockerExample.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialLockerExample.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private readonly ICredentialService _credentialService;

        public LoginViewModel(ICredentialService credentialService)
        {
            if (credentialService == null) throw new ArgumentNullException("credentialService");

            _credentialService = credentialService;
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }

        public void SaveCredentials()
        {
            var credential = new Credential { User = Username, Password = Password };
            _credentialService.SaveCredentials(credential);
        }

        public bool HasCredentials()
        {
            return _credentialService.GetCredentials().User != String.Empty && _credentialService.GetCredentials().Password != String.Empty;
        }

        public Credential GetCredentials()
        {
            return _credentialService.GetCredentials();
        }

        #region RaisePropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
