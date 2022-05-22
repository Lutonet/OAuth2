using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2Identity.Models
{
    internal class EncryptionSettings
    {
        public bool UseEncryption { get; }
        public string InitVector { get; }
        public string Passphrase { get; }
    }
}