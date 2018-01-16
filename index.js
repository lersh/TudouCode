'use strict'
var crypto = require('crypto');
var key = 'XDXDtudou@KeyFansClub^_^Encode!!';
var vector = 'Potato@Key@_@=_=';
var TudouKeyWord = ['冥', '奢', '梵', '呐', '俱', '哆', '怯', '諳', '罰', '侄', '缽', '皤'];
var TudouChar = [
    '滅', '苦', '婆', '娑', '耶', '陀', '跋', '多', '漫', '都', '殿', '悉', '夜', '爍', '帝', '吉',
    '利', '阿', '無', '南', '那', '怛', '喝', '羯', '勝', '摩', '伽', '謹', '波', '者', '穆', '僧',
    '室', '藝', '尼', '瑟', '地', '彌', '菩', '提', '蘇', '醯', '盧', '呼', '舍', '佛', '參', '沙',
    '伊', '隸', '麼', '遮', '闍', '度', '蒙', '孕', '薩', '夷', '迦', '他', '姪', '豆', '特', '逝',
    '朋', '輸', '楞', '栗', '寫', '數', '曳', '諦', '羅', '曰', '咒', '即', '密', '若', '般', '故',
    '不', '實', '真', '訶', '切', '一', '除', '能', '等', '是', '上', '明', '大', '神', '知', '三',
    '藐', '耨', '得', '依', '諸', '世', '槃', '涅', '竟', '究', '想', '夢', '倒', '顛', '離', '遠',
    '怖', '恐', '有', '礙', '心', '所', '以', '亦', '智', '道', '。', '集', '盡', '死', '老', '至'
];
var testStr = '陀呐真梵南諳呼呐世離缽集離道寫梵切佛他怯孕究亦';
var buff = new Buffer(testStr.length);
for (var n = 0, j = 0; n < testStr.length; n++ , j++) {
    if (TudouKeyWord.indexOf(testStr[n]) >= 0) {
        var char = TudouChar.indexOf(testStr[n + 1]);
        buff[j] = char ^ 128;
        n++;
    }
    else {
        buff[j] = TudouChar.indexOf(testStr[n]);
    }
}
console.dir(buff);
var data = buff.slice(0, buff.indexOf(0));
console.dir(data);

var decipher = crypto.createDecipheriv('aes-256-cbc', key, vector);
decipher.update(data);
var decoded = decipher.final();

var dataBuff = new Buffer(decoded);
console.dir(dataBuff);
console.log(dataBuff.toString('unicode'));