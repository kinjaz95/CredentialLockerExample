using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredentialLockerExample.Models
{
    public sealed class Credential
    {
        public string User { get; set; }

        public string Password { get; set; }
    }
}
