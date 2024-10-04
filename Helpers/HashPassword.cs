using System.Security.Cryptography;
using System.Text;

namespace ProjectMVCv._2.Helpers
{
    public static class HashPassword
    {
        public static string GeneratePassword(this string password)         
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(password);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array) 
            { 
                strHexa.Append(item.ToString("x2"));
            }
            return strHexa.ToString();
        }  
    }
}
