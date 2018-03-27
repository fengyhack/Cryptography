//////////////////////////////////////////////////////////////////////
//
// https://fengyh.cn
//
//////////////////////////////////////////////////////////////////////

using Microsoft.Practices.Unity;

namespace Cryptography
{
    /// <summary>
    /// 统一操作
    /// 封装了加密、解密模块
    /// </summary>
    class CryptoProvider
    {
        /// <summary>
        /// 文件签名(例如MD5校验码)
        /// </summary>
        [Dependency]
        public IEncryptable Encoder { get; set; }

        /// <summary>
        /// 加密/解密(例如AES128)
        /// </summary>
        [Dependency]
        public ISecure SecureCodec { get; set; }

        /// <summary>
        /// 文件签名(例如MD5校验码)
        /// </summary>
        /// <param name="content">原始内容</param>
        /// <returns>签名</returns>
        public string Sign(string content)
        {
            return Encoder.Encrypt(content);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="content">明文</param>
        /// <returns>密文</returns>
        public string Encrypt(string content)
        {
            return SecureCodec.Encrypt(content);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="content">密文</param>
        /// <returns>明文</returns>
        public string Decrypt(string content)
        {
            return SecureCodec.Decrypt(content);
        }
    }
}
