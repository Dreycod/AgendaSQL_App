using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSQL_App.Service
{
    class MD5Crypter
    {

        public static StringBuilder CrypterMot_de_passe(string MDP)
        {
            byte[] raw = UTF8Encoding.UTF8.GetBytes(MDP);
            byte[] hash;
            using (System.Security.Cryptography.MD5 md5hash = System.Security.Cryptography.MD5.Create())
            {
                hash = md5hash.ComputeHash(raw);
            }
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sBuilder.Append(hash[i].ToString("x2"));
            }
            return sBuilder;
        }

    }
}
