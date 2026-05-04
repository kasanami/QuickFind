using QuickFind;
using System.Text;

//Console.WriteLine("TrailingZeroCount");
//Console.WriteLine($"{uint.TrailingZeroCount(0b1)}");// 0
//Console.WriteLine($"{uint.TrailingZeroCount(0b10)}");// 1
//Console.WriteLine($"{uint.TrailingZeroCount(0b110)}");// 1
//Console.WriteLine($"{uint.TrailingZeroCount(0b1011)}");// 0

//Console.WriteLine("LeadingZeroCount");
//Console.WriteLine($"{uint.LeadingZeroCount(0)}");// 32
//Console.WriteLine($"{uint.LeadingZeroCount(0b1)}");// 31
//Console.WriteLine($"{uint.LeadingZeroCount(0b10)}");// 30
//Console.WriteLine($"{uint.LeadingZeroCount(0b110)}");// 29
//Console.WriteLine($"{uint.LeadingZeroCount(0b1011)}");// 28

#if false
for (int i = 32; i < 512; i++)
{
    Rune rune = new((uint)i);
    //Console.WriteLine($"{rune}\t{rune.Value:X}\t{Hash64.RuneToShift(rune)}");
    Console.WriteLine($"{rune}\t{rune.Value:X}\t{Hash64.RuneToShift(rune)}\t{Hash64.RuneToHash64(rune):X}");
}
#endif

#if false
string s = " 0Aあいうえおカキクケコ漢😀";
foreach (var rune in s.EnumerateRunes())
{
    //Console.WriteLine($"{rune}\t{rune.Value:X}\t{Hash64.RuneToShift(rune)}");
    Console.WriteLine($"{rune}\t{rune.Value:X}\t{Hash64.RuneToHash64(rune):X}");
}
#endif

var samples = new string[]
{
    "!!!!!",
    "12345",
    "Hello, World!",
    "Hash32",
    "C# 14.0",
    "ひらがな",
    "ひらがなカタカナ漢字"
};

foreach (var sample in samples)
{
     var hash = new Hash64(sample);
     Console.WriteLine($"{sample}→{hash.Value:X}");
}
