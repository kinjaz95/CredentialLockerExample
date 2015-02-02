using CredentialLockerExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialLockerExample.Services
{
    public interface ICredentialService
    {
        /// <summary>
        /// Gets the credentials for this App from the CredentialsLocker
        /// Returns the default-credentials if no credentials are saved
        /// </summary>
        /// <returns>Saved Credentials</returns>
        Credential GetCredentials();

        /// <summary>
        /// Saves the credentials in the CredentialsLocker
        /// It overwrites the existing Settings!!
        /// </summary>
        /// <param name="spCredentials">credentials to save</param>
        void SaveCredentials(Credential credential);
    }
}
