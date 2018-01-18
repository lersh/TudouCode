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
            string key = "XDXDtudou@KeyFansClub^_^Encode!!";
            string vector = "Potato@Key@_@=_=";
            // Console.WriteLine("Hello World!");
            string foText = "知息王如鄉修槃梭橋涅倒修創告故求提昼毒进惜住祖貧者積時闍慈敬灭廟皂求闍路友依廣文弟须舍藐弟槃修捐困众創紛七花藥名央僧持弥来数此怖者茶楞婦消訶北槃阿迦和定路依通过灯實粟實盡施忧廣尼夢以王号戒槃戏雙师中念及灯在麼戏經焰过竟灯七虚阿清捐信以閦多豆刚舍师真央璃困友修輸礙憐他便急多僧藥隸先六万宝尊禮豆树者乾提去方奉姪睦心休拔藥须醯诵亦急困夷陀濟令功东祖實界路路中夫諦麼释足贤真和宝路北礙如瑟以睦恐殿亿尼如彌盧輸须姪乾禮亿通睦息急鄉贤實焰盧西焰顛昼慈精中麼放央进茶心弟修东劫寡昼虚知能陀尊文普药憐北释游帝帝經孫住真竟積东殿難闍持休东盧亦胜令造释拔婦未下夫乾利宇尼行困陰施迦求弥灭求昼呼夫帝山婦知清排忧在瑟牟哈五礙百便普便各穆死姪高毘陵蒙夷恤诸婦和排信忧禮凉焰守兄楞訶室万薩夢诸德盡树朋根彌伊戏戒特勒宗恐橋便特排提此排族顛至心量毘曳急持进幽謹金孫朋休阿蘇害高想室勒蘇功貧闍高友智倒閦能未休故夷惜住輸刚怖茶智安尼王刚帝恤空功忧释彌首夢中念吼师兄廣特遮友戒根孕經说吼心文德亦方高竟寫于放究毒福凉生彌尼寡善方灭蒙施千薩善稳隸夫寫清創亦梭弥住夢过行和彌阿过求花紛来乾游時令去恤度僧";

            byte[] buff = Tudou2.ToBytes(foText);

            byte[] decodeBuff = AES.AESDecrypt(buff, key, vector);





            using (MemoryStream stream = new MemoryStream(decodeBuff))
            {
                var archive = SharpCompress.Archives.SevenZip.SevenZipArchive.Open(stream);
                foreach (var item in archive.Entries)
                {
                    Console.WriteLine(item.IsDirectory + ":" + item.Key);
                }
            }

            using (var archive = SharpCompress.Archives.Zip.ZipArchive.Create())
            {
                string str = "今天晚上和@熊对羊的感情很特别 姐姐聊天通话，我是一个比较封闭自己的一个人，每天一个人生活 吃饭 旅游 看微博 听歌，在无意中认识了@熊对羊的感情很特别 后，发觉手机的另一端有一个陌生人在关心自己，顿时感觉自己充满了能量。现在每天看@熊对羊的感情很特别 感觉我在同龄人中对投资有比别人更深刻的认识了，也让我一个人走走停停的生活充满了正能量，感谢您，感谢不冰冷的网络。[哈哈]";
                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(str));
                archive.AddEntry("default", stream);

                MemoryStream buffStream = new MemoryStream();
                archive.SaveTo(buffStream,new WriterOptions(CompressionType.LZMA));
                byte[] encodeBuff = AES.AESEncrypt(buffStream.ToArray(), key, vector);
                string result = String.Empty;
                char[] TudouChar = new char[] {
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
                foreach (var code in encodeBuff)
                {
                    result += TudouChar[code];
                }
                Console.Write(result);

            }
        }
    }
}
