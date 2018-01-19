using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TudouSharp
{
    public class Tudou
    {
        private static string key = "XDXDtudou@KeyFansClub^_^Encode!!";
        private static string vector = "Potato@Key@_@=_=";

        private static char[] TudouKeyWord = { '冥', '奢', '梵', '呐', '俱', '哆', '怯', '諳', '罰', '侄', '缽', '皤' };
        private static char[] TudouChar = new char[] {
            '滅', '苦', '婆', '娑', '耶', '陀', '跋', '多', '漫', '都', '殿', '悉', '夜', '爍', '帝', '吉',
            '利', '阿', '無', '南', '那', '怛', '喝', '羯', '勝', '摩', '伽', '謹', '波', '者', '穆', '僧',
            '室', '藝', '尼', '瑟', '地', '彌', '菩', '提', '蘇', '醯', '盧', '呼', '舍', '佛', '參', '沙',
            '伊', '隸', '麼', '遮', '闍', '度', '蒙', '孕', '薩', '夷', '迦', '他', '姪', '豆', '特', '逝',
            '朋', '輸', '楞', '栗', '寫', '數', '曳', '諦', '羅', '曰', '咒', '即', '密', '若', '般', '故',
            '不', '實', '真', '訶', '切', '一', '除', '能', '等', '是', '上', '明', '大', '神', '知', '三',
            '藐', '耨', '得', '依', '諸', '世', '槃', '涅', '竟', '究', '想', '夢', '倒', '顛', '離', '遠',
            '怖', '恐', '有', '礙', '心', '所', '以', '亦', '智', '道', '。', '集', '盡', '死', '老', '至'
            };
        public static string Decode(string EncodeText)
        {

            byte[] EncodeBuffer = ToBytes(EncodeText);
            byte[] DecodeBuff = AES.AESDecrypt(EncodeBuffer, key, vector);

            return Encoding.Unicode.GetString(DecodeBuff);
        }

        private static byte[] ToBytes(string TudouString)
        {
            List<char> TudouKeyWordList = new List<char>(TudouKeyWord);
            List<char> TudouCharList = new List<char>(TudouChar);
            byte[] encodeBuffer = new byte[TudouString.Length];

            int j = 0;

            for (int i = 0; i < TudouString.Length; i++, j++)
            {
                if (TudouKeyWordList.Contains(TudouString[i]))
                {
                    encodeBuffer[j] = (byte)(TudouCharList.IndexOf(TudouString[i + 1]) ^ 0x80);
                    i++;
                }
                else
                {
                    encodeBuffer[j] = (byte)(TudouCharList.IndexOf(TudouString[i]));
                }
            }
            List<byte> encodeBufferList = new List<byte>(encodeBuffer);
            byte[] trimedBuffer = encodeBufferList.GetRange(0, j).ToArray();

            return trimedBuffer;
        }


        public static string Encode(string OriginalString)
        {
            Random rand = new Random();
            byte[] originalBuffer = Encoding.Unicode.GetBytes(OriginalString);
            byte[] encodeBuffer = AES.AESEncrypt(originalBuffer, key, vector);
            string TudouString = String.Empty;
            for (int i = 0; i < encodeBuffer.Length; i++)
            {
                if (encodeBuffer[i] >= 0x80)
                {
                    TudouString += TudouKeyWord[rand.Next(TudouKeyWord.Length)];
                    TudouString += TudouChar[encodeBuffer[i] ^ 0x80];
                }
                else
                {
                    TudouString += TudouChar[encodeBuffer[i]];
                }
            }

            return TudouString;
        }
    }
}
