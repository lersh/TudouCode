using System;
using System.IO;
using System.Text;

namespace TudouSharp
{
    public class Router
    {
        static private string TudouHead = "佛曰：";
        static private string Tudou2Head = "如是我闻：";

        private struct TudouBody
        {
            public int CodeMethod;
            public string CodeString;
        }
        private static TudouBody GetCode(string TudouString)
        {
            TudouBody body;
            if (TudouString.Length < 3)
            {
                body.CodeMethod = -1;
                body.CodeString = String.Empty;
                return body;
            }
            else if (TudouString.Substring(0, TudouHead.Length) == TudouHead)
            {
                body.CodeMethod = 1;
                body.CodeString = TudouString.Substring(TudouHead.Length);
                return body;
            }
            else if (TudouString.Substring(0, Tudou2Head.Length) == Tudou2Head)
            {
                body.CodeMethod = 2;
                body.CodeString = TudouString.Substring(Tudou2Head.Length);
                return body;
            }
            else
            {
                body.CodeMethod = 0;
                body.CodeString = String.Empty;
                return body;
            }
        }


    }
}