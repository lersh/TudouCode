using System;

namespace TudouSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            string tudouString = args[0];
            string decodeString = Tudou.Decode(tudouString);

            Console.WriteLine(decodeString);
        }
    }
}
