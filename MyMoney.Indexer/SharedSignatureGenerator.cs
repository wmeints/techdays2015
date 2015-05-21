using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney.Indexer
{
    public class SharedSignatureGenerator
    {
        private string keyName;
        private string keyValue;

        public SharedSignatureGenerator(string keyName, string keyValue)
        {
            this.keyName = keyName;
            this.keyValue = keyValue;
        }

        public string Generate(string url)
        {
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(keyValue));
            TimeSpan fromEpochStart = DateTime.UtcNow - new DateTime(1970, 1, 1);

            string expiry = Convert.ToString((int)fromEpochStart.TotalSeconds + 3600);
            string stringToSign = Uri.EscapeDataString(url) + "\n" + expiry;

            string signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));

            string sasToken = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}",
                Uri.EscapeDataString(url), Uri.EscapeDataString(signature), expiry, keyName);

            return sasToken;
        }
    }
}
