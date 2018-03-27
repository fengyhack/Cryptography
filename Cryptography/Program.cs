//////////////////////////////////////////////////////////////////////
//
// https://fengyh.cn
//
//////////////////////////////////////////////////////////////////////

using System;
using System.Text;

namespace Cryptography
{
    /// <summary>
    /// 加密/解密模块 使用示例
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 假设脚本文件内容有N行
            string s = "a2b3c4d5e6f7g8h9i0j1k2l3m4n5o6p7q9r0s1t2u3v4w5";
            const int N = 1000;
            StringBuilder sb = new StringBuilder(s.Length * N);
            for (int n = 0; n < N; ++n)
            {
                sb.Append(s);
                sb.AppendLine(s);
            }
            string str = sb.ToString();
            System.IO.File.WriteAllText("content.txt", str);

            // 加密/解密提供者
            CryptoProvider cryptoProvider = SimpleIoc.GetInstanceDAL<CryptoProvider>();

            // 循环次数LOOP，取均值
            const int LOOP = 100;
            
            var stw = new System.Diagnostics.Stopwatch();
            stw.Start();

            try
            {
                for (int i = 0; i < LOOP; ++i)
                {
                    string signature = cryptoProvider.Sign(str);
                }
            }
            catch (Exception)
            { }
            
            stw.Stop();

            // 测算单个文件平均耗时
            Console.WriteLine($"Average time = {stw.Elapsed.TotalMilliseconds / LOOP}ms");

            Console.ReadKey();
        }
    }
}
