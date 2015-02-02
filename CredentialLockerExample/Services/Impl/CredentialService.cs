using CredentialLockerExample.Models;
using CredentialLockerExample.Models.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace CredentialLockerExample.Services.Impl
{
    public class CredentialService : ICredentialService
    {
        private readonly PasswordVault _vault = new PasswordVault();
        private readonly CredentialsFactory _factory;
        private string _resourceName = "CredentialLockerExample";

        public CredentialService( CredentialsFactory factory)
        {
            if (factory == null) throw new ArgumentNullException("factory");

            _factory = factory;
        }

        public Credential GetCredentials()
        {
            try
            {
                if (_vault.RetrieveAll().All(vault => vault.Resource != _resourceName)) return _factory.GetDefaultObject();

                var credentials = _vault.FindAllByResource(_resourceName).First();

                credentials.RetrievePassword();

                var spCredential = _factory.CreateCredentials(credentials.UserName, credentials.Password);
                return spCredential;
            }
            catch (Exception)
            {
            }
                return _factory.GetDefaultObject();
        }

        public void SaveCredentials(Credential credential)
        {
            if (credential == null) throw new ArgumentNullException("credential");

            if (_vault.RetrieveAll().Any(vault => vault.Resource == _resourceName))
            {
                _vault.Remove(_vault.FindAllByResource(_resourceName).First());
            }

            var pwCredential = new PasswordCredential(_resourceName, credential.User, credential.Password);

            _vault.Add(pwCredential);
        }
    }
}
