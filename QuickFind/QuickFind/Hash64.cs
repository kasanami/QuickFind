using System;
using System.Collections.Generic;
using System.Text;

namespace QuickFind
{
    /// <summary>
    /// 文字列に使用されている文字の種類で決めたハッシュ値
    /// ・同じ文字を含む文字列は同じハッシュ値になる。
    /// ・異なる文字を含む文字列は異なるハッシュ値になる可能性が高い。
    /// ・コードポイントが小さい文字は、1が立つビット位置が小さくなる。
    /// ・コードポイントが大きい文字は、1が立つビット位置が大きくなる。
    /// ・コードポイントの最下位ビット２桁は、シフト数に足されます。
    /// 
    /// 例：
    /// 記号・・・0x1～2
    /// 数字・・・0x4～8
    /// 英字・・・0x10～80
    /// かな・・・0x400000000等
    /// 漢字・・・0x4000000000等
    /// 絵文字・・0x800000000000等
    /// </summary>
    public struct Hash64
    {
        /// <summary>
        /// ハッシュ値
        /// </summary>
        public UInt64 Value { get; set; } = 0;

        public Hash64(UInt64 value)
        {
            Value = value;
        }
        public Hash64(string str) : this(str.AsSpan())
        {
        }
        public Hash64(ReadOnlySpan<char> str)
        {
            foreach (var rune in str.EnumerateRunes())
            {
                Value |= RuneToHash64(rune);
            }
        }
        /// <summary>
        /// 文字の値をビットフラグに変換する
        /// </summary>
        /// <param name="rune">文字</param>
        /// <returns></returns>
        public static UInt64 RuneToHash64(Rune rune)
        {
            return (UInt64)1 << RuneToShift(rune);
        }
        /// <summary>
        /// コードポイントからシフトする量を計算する
        /// 例：
        /// U+0000～U+001F	ASCII	制御文字・・・0を返す
        /// U+0000～U+007F	ASCII	英数字
        /// U+0080～U+07FF 各国文字    ラテン文字拡張、ギリシャ文字など
        /// U+0800～U+FFFF BMP 日本語、中国語、インド系文字など
        /// U+10000～U+10FFFF 追加面 絵文字、古代文字など
        /// 仮にU+10FFFFを超える場合は0を返す。
        /// </summary>
        public static int RuneToShift(Rune rune)
        {
            int codePoint = rune.Value;
            if (codePoint <= 0x1F)
            {
                return 0;
            }
            else if (codePoint > 0x10FFFF)
            {
                return 0;
            }
            // 先頭のゼロの数を数える
            // 0b0010_0000	空白文字　・・・26→6
            // 0x3042 ひらがな　・・・18→14
            // 0x1F600　絵文字　・・・15→17
            // 0x10FFFF　　・・・11→21
            var leadingZeroCount = int.LeadingZeroCount(codePoint);
            var shift = 32 - leadingZeroCount;
            if (shift < 6)
            {
                return 0;
            }
            // 6～21→0～15
            shift -= 6;
            // 0～15→0～60
            shift *= 4;
            // 最下位ビット2ビット(0～3)の値を加える
            return shift + (codePoint & 0b11);
        }
    }
}