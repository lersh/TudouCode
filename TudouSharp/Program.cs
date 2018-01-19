using System;
using System.IO;
using System.Text;
using SharpCompress;
using SharpCompress.Archives;
using SharpCompress.Common;
using SharpCompress.Writers;
using SharpCompress.Compressors;

namespace TudouSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("请指定方法和参数。");
            }
            else
            {
                string method = args[0];
                if (method.ToLower() == "encode")
                {
                    Console.WriteLine(Tudou2.Encode(args[1]));
                }
                else if (method.ToLower() == "decode")
                {
                    Console.WriteLine(Tudou2.Decode(args[1]));
                }
            }





        }
    }
}
