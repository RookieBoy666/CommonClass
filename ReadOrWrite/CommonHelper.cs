using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ReadOrWrite
{
  public  class CommonHelper
    {
        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="encryptString"></param>
        /// <returns></returns>
        public static string Encode(string encryptString)
        {
            try
            {
                string KEY = "zjp1202!";
                byte[] _vector = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

                var rgbKey = Encoding.UTF8.GetBytes(KEY.Substring(0, 8));
                var des = new DESCryptoServiceProvider();

                var inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, des.CreateEncryptor(rgbKey, _vector), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
       /// <summary>
       ///字符串解密
       /// </summary>
       /// <param name="decryptString"></param>
       /// <returns></returns>
        public static string Decode(string decryptString)
        {
            try
            {
                string KEY = "zjp1202!";
                byte[] _vector = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                var provider = new DESCryptoServiceProvider();
                var rgbKey = Encoding.UTF8.GetBytes(KEY.Substring(0, 8));

                var inputByteArray = Convert.FromBase64String(decryptString);

                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, provider.CreateDecryptor(rgbKey, _vector), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                var encoding = new UTF8Encoding();

                return encoding.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
