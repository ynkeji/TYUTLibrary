using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BytesIO.TCP_Client.util
{

    public class aes
    {


        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="decryptString">AES密文</param>
        /// <param name="key">秘钥（44个字符）</param>
        /// <param name="ivString">向量（16个字符）</param>
        /// <returns></returns>
        public static string AES_Decrypt(string decryptString, string key, string ivString)
        {
            try
            {

                key = key.PadRight(32, ' ');
                RijndaelManaged aes = new RijndaelManaged();

                byte[] iv = Encoding.UTF8.GetBytes(ivString.Substring(0, 16));
                aes.Key = Encoding.UTF8.GetBytes(key.Substring(0, 32));
                aes.Mode = CipherMode.ECB;
                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;  //


                ICryptoTransform rijndaelDecrypt = aes.CreateDecryptor();
                byte[] inputData = Convert.FromBase64String(decryptString);
                byte[] xBuff = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);

                return Encoding.UTF8.GetString(xBuff);
            }
            catch (Exception ex)
            {
                throw;

            }
        }



        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encriyptString">要被加密的字符串</param>
        /// <param name="key">秘钥（44个字符）</param>
        /// <param name="ivString">向量长度（16个字符）</param>
        /// <returns></returns>
        public static string AES_Encrypt(string encriyptString)
        {
            string key= $"{DateTime.Now.ToString("yyyyMMdd")}" + ReverseUsingCharArray($"{DateTime.Now.ToString("yyyyMMdd")}");
            string ivString = "ZZWBKJ_ZHIHUAWEI";
            SymmetricAlgorithm aes = new RijndaelManaged();
            byte[] iv = Encoding.UTF8.GetBytes(ivString.Substring(0, 16));
            aes.Key = Encoding.UTF8.GetBytes(key.Substring(0, 16));
            aes.Mode = CipherMode.CBC;
            aes.IV = iv;
            aes.Padding = PaddingMode.PKCS7; //
            ICryptoTransform rijndaelEncrypt = aes.CreateEncryptor();
            byte[] inputData = Encoding.UTF8.GetBytes(encriyptString);
            byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);
            Console.Error.WriteLine(encryptedData.ToString());
            return Convert.ToBase64String(encryptedData);
        }


        /// <summary>
        /// 字符串逆转-CharArray实现
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReverseUsingCharArray(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
