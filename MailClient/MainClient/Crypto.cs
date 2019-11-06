using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MainClient
{
    class Crypto
    {
        public string Hesh(string Input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(Input));
                return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
            }
        }
    }
}