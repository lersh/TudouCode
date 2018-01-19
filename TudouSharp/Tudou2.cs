using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TudouSharp
{
    public class Tudou2
    {
        static string key = "XDXDtudou@KeyFansClub^_^Encode!!";
        static string vector = "Potato@Key@_@=_=";
        static char[] TudouChar = new char[] {
            '謹', '穆', '僧', '室', '藝', '瑟', '彌', '提', '蘇', '醯', '盧', '呼', '舍', '參', '沙', '伊',
            '隸', '麼', '遮', '闍', '度', '蒙', '孕', '薩', '夷', '他', '姪', '豆', '特', '逝', '輸', '楞',
            '栗', '寫', '數', '曳', '諦', '羅', '故', '實', '訶', '知', '三', '藐', '耨', '依', '槃', '涅',
            '竟', '究', '想', '夢', '倒', '顛', '遠', '怖', '恐', '礙', '以', '亦', '智', '盡', '老', '至',
            '吼', '足', '幽', '王', '告', '须', '弥', '灯', '护', '金', '刚', '游', '戏', '宝', '胜', '通',
            '药', '师', '琉', '璃', '普', '功', '德', '山', '善', '住', '过', '去', '七', '未', '来', '贤',
            '劫', '千', '五', '百', '万', '花', '亿', '定', '六', '方', '名', '号', '东', '月', '殿', '妙',
            '尊', '树', '根', '西', '皂', '焰', '北', '清', '数', '精', '进', '首', '下', '寂', '量', '诸',
            '多', '释', '迦', '牟', '尼', '勒', '阿', '閦', '陀', '中', '央', '众', '生', '在', '界', '者',
            '行', '于', '及', '虚', '空', '慈', '忧', '各', '令', '安', '稳', '休', '息', '昼', '夜', '修',
            '持', '心', '求', '诵', '此', '经', '能', '灭', '死', '消', '除', '毒', '害', '高', '开', '文',
            '殊', '利', '凉', '如', '念', '即', '说', '曰', '帝', '毘', '真', '陵', '乾', '梭', '哈', '敬',
            '禮', '奉', '祖', '先', '孝', '雙', '親', '守', '重', '師', '愛', '兄', '弟', '信', '朋', '友',
            '睦', '宗', '族', '和', '鄉', '夫', '婦', '教', '孫', '時', '便', '廣', '積', '陰', '難', '濟',
            '急', '恤', '孤', '憐', '貧', '創', '廟', '宇', '印', '造', '經', '捨', '藥', '施', '茶', '戒',
            '殺', '放', '橋', '路', '矜', '寡', '拔', '困', '粟', '惜', '福', '排', '解', '紛', '捐', '資'
            };
        public static byte[] ToBytes(string TudouString)
        {
            List<char> TudouCharList = new List<char>(TudouChar);

            byte[] buffer;
            using (MemoryStream stream = new MemoryStream())
            {
                foreach (char word in TudouString)
                {
                    int index = TudouCharList.IndexOf(word);
                    stream.WriteByte((byte)index);
                }
                buffer = stream.ToArray();
            }

            return buffer;
        }

        public static string Decode(string EncodeText)
        {
            byte[] EncodeBuffer = ToBytes(EncodeText);
            byte[] DecodeBuffer = AES.AESDecrypt(EncodeBuffer, key, vector);
            byte[] DecompressBuffer = new byte[] { };
            DecompressBuffer = Compress.Decompress(DecodeBuffer);

            return Encoding.UTF8.GetString(DecompressBuffer);
        }

        public static string Encode(string OriginalText)
        {
            byte[] OriginalBuffer = Encoding.UTF8.GetBytes(OriginalText);
            byte[] CompressedBuffer = Compress.CompressZip(OriginalBuffer);
            byte[] EncodeBuffer = AES.AESEncrypt(CompressedBuffer, key, vector);
            string EncodeString = String.Empty;
            foreach (var word in EncodeBuffer)
            {
                EncodeString += TudouChar[word];
            }

            return EncodeString;
        }
    }
}