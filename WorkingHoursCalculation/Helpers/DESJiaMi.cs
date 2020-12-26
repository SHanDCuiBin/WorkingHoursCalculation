using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WorkingHoursCalculation.Helpers
{
    class DESJiaMi
    {
        private static string sKey = "123456";
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="stringToEncrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Encrypt(string stringToEncrypt)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.GetEncoding("UTF-8").GetBytes(stringToEncrypt);
                des.Key = ASCIIEncoding.UTF8.GetBytes(sKey);
                des.IV = ASCIIEncoding.UTF8.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                ret.ToString();
                return ret.ToString();
            }
            catch (Exception ee)
            {
                return stringToEncrypt;
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="stringToDecrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Decrypt(string stringToDecrypt)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = new byte[stringToDecrypt.Length / 2];
                for (int x = 0; x < stringToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(stringToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }
                des.Key = ASCIIEncoding.UTF8.GetBytes(sKey);
                des.IV = ASCIIEncoding.UTF8.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder ret = new StringBuilder();
                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch (Exception ee)
            {
                return stringToDecrypt;
            }

        }
    }
}
