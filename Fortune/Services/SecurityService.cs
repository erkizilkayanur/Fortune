using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Fortune.Services
{
    public interface ISecurityService
    {
        string Sha256(string input, string salt, string key);
        string GenerateSalt();
    }
    public class SecurityService: ISecurityService
    {

        public string GenerateSalt()
        {
            var provider = new RNGCryptoServiceProvider();

            var buffer = new byte[128];

            provider.GetBytes(buffer);

            return Convert.ToBase64String(buffer);
        }


        public string Sha256(string input, string salt, string key)
        {

            var bytes = Encoding.UTF8.GetBytes(input + salt);

            var algorihm = new HMACSHA256(Encoding.UTF8.GetBytes(key));

            byte[] hash = algorihm.ComputeHash(bytes);

            return string.Concat(hash.Select(x => x.ToString("X2")).ToArray());
        }

    }
}
