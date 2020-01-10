using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EnumProject.Helper
{
    public class PasswordHelper
    {
        //[Obsolete("The recommended alternative is to use the Membership APIs, such as Membership.CreateUser. For more information, see http://go.microsoft.com/fwlink/?LinkId=252463.")]
        #region 加密方法
        public static string HashPasswordForStoringInConfigFile(string password, string passwordFormat)
        {
            string result = "";
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            if (passwordFormat == null)
            {
                throw new ArgumentNullException("passwordFormat");
            }
            HashAlgorithm hashAlgorithm;
            switch (passwordFormat)
            {
                case "sha1":
                    hashAlgorithm = new SHA1Cng();
                    break;
                case "md5":
                    hashAlgorithm = new MD5Cng();
                    break;
                case "sha256":
                    hashAlgorithm = new HMACSHA256();
                    break;
                case "sha384":
                    hashAlgorithm = new HMACSHA384();
                    break;
                case "sha512":
                    hashAlgorithm = new HMACSHA512();
                    break;
                default:
                    throw new ArgumentException("加解密类型不存在");
            }
            using (hashAlgorithm)
            {
                byte[] bt = Encoding.UTF8.GetBytes(password);
                byte[] btp = hashAlgorithm.ComputeHash(bt);

                foreach (byte num in btp)
                {
                    if (num < 0x10)
                    {
                        result = result + "0" + num.ToString("X");
                    }
                    else
                    {
                        result = result + num.ToString("X");
                    }
                }
            }
            return result;
        }
        #endregion
        #region 解密方法
        public static string HashTextForStoringInConfigFile(string text, string passwordFormat)
        {
            string result = "";
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            if (passwordFormat == null)
            {
                throw new ArgumentNullException("passwordFormat");
            }
            HashAlgorithm hashAlgorithm;
            switch (passwordFormat)
            {
                case "sha1":
                    hashAlgorithm = new SHA1Cng();
                    break;
                case "md5":
                    hashAlgorithm = new MD5Cng();
                    break;
                case "sha256":
                    hashAlgorithm = new HMACSHA256();
                    break;
                case "sha384":
                    hashAlgorithm = new HMACSHA384();
                    break;
                case "sha512":
                    hashAlgorithm = new HMACSHA512();
                    break;
                default:
                    throw new ArgumentException("加解密类型不存在");
            }
            using (hashAlgorithm)
            {
                byte[] bt = Encoding.UTF8.GetBytes(text);
                byte[] btp = hashAlgorithm.ComputeHash(bt);
                result =Encoding.UTF8.GetString(btp);
            }
            return result;
        }
        #endregion


    }
}
