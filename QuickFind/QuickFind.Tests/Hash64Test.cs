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
            Assert.Equal(0, Hash64.RuneToShift(new(0b0001_1111)));

            Assert.Equal(0, Hash64.RuneToShift(new(0b0010_0000)));
            Assert.Equal(1, Hash64.RuneToShift(new(0b0010_0001)));
            Assert.Equal(2, Hash64.RuneToShift(new(0b0010_0010)));
            Assert.Equal(3, Hash64.RuneToShift(new(0b0010_0011)));
            Assert.Equal(0, Hash64.RuneToShift(new(0b0010_0100)));
            Assert.Equal(1, Hash64.RuneToShift(new(0b0010_0101)));
            Assert.Equal(2, Hash64.RuneToShift(new(0b0010_0110)));
            Assert.Equal(3, Hash64.RuneToShift(new(0b0010_0111)));

            Assert.Equal(4, Hash64.RuneToShift(new(0b0100_0000)));
            Assert.Equal(5, Hash64.RuneToShift(new(0b0100_0001)));
            Assert.Equal(6, Hash64.RuneToShift(new(0b0100_0010)));
            Assert.Equal(7, Hash64.RuneToShift(new(0b0100_0011)));
            Assert.Equal(4, Hash64.RuneToShift(new(0b0100_0100)));
            Assert.Equal(5, Hash64.RuneToShift(new(0b0100_0101)));
            Assert.Equal(6, Hash64.RuneToShift(new(0b0100_0110)));
            Assert.Equal(7, Hash64.RuneToShift(new(0b0100_0111)));

            Assert.Equal(08, Hash64.RuneToShift(new(0b1000_0000)));
            Assert.Equal(09, Hash64.RuneToShift(new(0b1000_0001)));
            Assert.Equal(10, Hash64.RuneToShift(new(0b1000_0010)));
            Assert.Equal(11, Hash64.RuneToShift(new(0b1000_0011)));
            Assert.Equal(08, Hash64.RuneToShift(new(0b1000_0100)));
            Assert.Equal(09, Hash64.RuneToShift(new(0b1000_0101)));
            Assert.Equal(10, Hash64.RuneToShift(new(0b1000_0110)));
            Assert.Equal(11, Hash64.RuneToShift(new(0b1000_0111)));

            Assert.Equal(60, Hash64.RuneToShift(new(0x10FFF0)));
            Assert.Equal(61, Hash64.RuneToShift(new(0x10FFF1)));
            Assert.Equal(62, Hash64.RuneToShift(new(0x10FFF2)));
            Assert.Equal(63, Hash64.RuneToShift(new(0x10FFF3)));

            Assert.Equal(63, Hash64.RuneToShift(new(0x10FFFF)));
        }
    }
}
