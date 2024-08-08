using HouseIt.ConsoleApp;

namespace HouseIt.Tests
{
    public class UserInterfaceExtensionsTest
    {
        [Theory]
        [InlineData("123", true)]
        [InlineData("d12s", false)]
        [InlineData(null, false)]
        public void Given_Various_Integer_Values_When_Executing_TryConvert_Expected_Result_Is_Returned(string? value, bool expected)
        {
            var actual = value.TryConvert<int>(out _);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("123", true)]
        [InlineData("d12s", true)]
        [InlineData(null, false)]
        public void Given_Various_String_Values_When_Executing_TryConvert_Expected_Result_Is_Returned(string? value, bool expected)
        {
            var actual = value.TryConvert<string>(out _);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Value1", true)]
        [InlineData("Value2", true)]
        [InlineData("Not a Value", false)]
        public void Given_Various_Enum_Values_When_Executing_TryConvert_Expected_Result_Is_Returned(string? value, bool expected)
        {
            var actual = value.TryConvert<TestEnum>(out _);
            Assert.Equal(expected, actual);
        }

        private enum TestEnum
        {
            Value1,
            Value2
        }
    }
}
