using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace TudouSharp
{
    public class AES
    {
        public static byte[] AESDecrypt(byte[] Data, string Key, string Vector)
        {
            byte[] destinationArray = new byte[0x20];
            Array.Copy(Encoding.UTF8.GetBytes(Key.PadRight(destinationArray.Length)), destinationArray, destinationArray.Length);
            byte[] ivArray = new byte[0x10];
            Array.Copy(Encoding.UTF8.GetBytes(Vector.PadRight(ivArray.Length)), ivArray, ivArray.Length);
            byte[] buffer3 = null;
            Rijndael rijndael = Rijndael.Create();
            try
            {
                using (MemoryStream stream = new MemoryStream(Data))
                {
                    using (CryptoStream stream2 = new CryptoStream(stream, rijndael.CreateDecryptor(destinationArray, ivArray), CryptoStreamMode.Read))
                    {
                        using (MemoryStream stream3 = new MemoryStream())
                        {
                            byte[] buffer = new byte[0x400];
                            int count = 0;
                            while ((count = stream2.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                stream3.Write(buffer, 0, count);
                            }
                            return stream3.ToArray();
                        }
                    }
                }
            }
            catch
            {
                buffer3 = null;
            }
            return buffer3;
        }


        public static byte[] AESEncrypt(byte[] Data, string Key, string Vector)
        {
            byte[] destinationArray = new byte[0x20];
            Array.Copy(Encoding.UTF8.GetBytes(Key.PadRight(destinationArray.Length)), destinationArray, destinationArray.Length);
            byte[] ivArray = new byte[0x10];
            Array.Copy(Encoding.UTF8.GetBytes(Vector.PadRight(ivArray.Length)), ivArray, ivArray.Length);
            byte[] buffer3 = null;
            Rijndael rijndael = Rijndael.Create();
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    using (CryptoStream stream2 = new CryptoStream(stream, rijndael.CreateEncryptor(destinationArray, ivArray), CryptoStreamMode.Write))
                    {
                        stream2.Write(Data, 0, Data.Length);
                        stream2.FlushFinalBlock();
                        stream2.Close();
                        return stream.ToArray();
                    }
                }
            }
            catch (Exception e)
            {
                buffer3 = Encoding.UTF8.GetBytes(e.ToString());
            }
            return buffer3;
        }

    }
}
