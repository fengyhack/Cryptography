//////////////////////////////////////////////////////////////////////
//
// https://fengyh.cn
//
//////////////////////////////////////////////////////////////////////

using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    /// <summary>
    /// 基于System.Security.Cryptography实现
    /// </summary>
    class MD5 :IEncryptable
    {
        public string Encrypt(string content)
        {
            return CalcMD5(content);
        }

        #region Private

        /// <summary>
        /// 计算MD5哈希(可能需要关闭FIPS)
        /// </summary>
        /// <param name="str">待计算的字符串</param>
        /// <returns>MD5结果</returns>
        private static string CalcMD5(string str)
        {
#if WINDOWS_UWP
            var md5 = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            var buf = CryptographicBuffer.ConvertStringToBinary(str, BinaryStringEncoding.Utf8);
            var digest = md5.HashData(buf);
            return CryptographicBuffer.EncodeToHexString(digest);
#else
            var md5 = HMACMD5.Create();
            byte[] data = Encoding.UTF8.GetBytes(str);
            byte[] hashData = md5.ComputeHash(data);
            StringBuilder sb = new StringBuilder(hashData.Length * 2);
            foreach (byte b in hashData)
            {
                sb.AppendFormat("{0:X2}", b);
            }
            return sb.ToString();
#endif
        }

        #endregion Private

    }
}
