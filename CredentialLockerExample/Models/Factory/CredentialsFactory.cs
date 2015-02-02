using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialLockerExample.Models.Factory
{
    public sealed class CredentialsFactory
    {
        public Credential GetDefaultObject()
        {
            var defaultObject = new Credential
            {
                Password = string.Empty,
                User = string.Empty,
            };

            return defaultObject;
        }

        public Credential CreateCredentials(string user, string password)
        {
            var newObject = new Credential
            {
                Password = password,
                User = user,
            };

            return newObject;
        }
    }
}
