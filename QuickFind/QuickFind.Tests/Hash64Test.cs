using System.Text;

namespace QuickFind.Tests
{
    public class Hash64Test
    {
        [Fact]
        public void RuneToShiftTest()
        {
            Assert.Equal(0, Hash64.RuneToShift(new(0b0000_0000)));
            Assert.Equal(0, Hash64.RuneToShift(new(0b0000_0001)));
            Assert.Equal(0, Hash64.RuneToShift(new(0b0000_0010)));
            Assert.Equal(0, Hash64.RuneToShift(new(0b0000_0100)));
            Assert.Equal(0, Hash64.RuneToShift(new(0b0000_1000)));
            Assert.Equal(0, Hash64.RuneToShift(new(0b0001_0000)));
            Assert.Equal(0, Hash64.RuneToShift(new(0b0010_0000)));
            Assert.Equal(1, Hash64.RuneToShift(new(0b0010_1000)));
            Assert.Equal(2, Hash64.RuneToShift(new(0b0011_0000)));
            Assert.Equal(3, Hash64.RuneToShift(new(0b0011_1000)));

            Assert.Equal(4, Hash64.RuneToShift(new(0b0100_0000)));
            Assert.Equal(5, Hash64.RuneToShift(new(0b0101_0000)));
            Assert.Equal(6, Hash64.RuneToShift(new(0b0110_0000)));
            Assert.Equal(7, Hash64.RuneToShift(new(0b0111_0000)));

            Assert.Equal(8,  Hash64.RuneToShift(new(0b1000_0000)));
            Assert.Equal(9,  Hash64.RuneToShift(new(0b1010_0000)));
            Assert.Equal(10, Hash64.RuneToShift(new(0b1100_0000)));
            Assert.Equal(11, Hash64.RuneToShift(new(0b1110_0000)));

            Assert.Equal(60, Hash64.RuneToShift(new(0x10FFFF)));
        }
    }
}
