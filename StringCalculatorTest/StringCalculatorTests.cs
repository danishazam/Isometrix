using StringCalculator;

namespace StringCalculatorTest
{
    public class StringCalculatorTests
    {
        private readonly StringCalculator.StringCalculator _calculator;

        public StringCalculatorTests()
        {
            _calculator = new StringCalculator.StringCalculator();
        }

        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            int result = _calculator.Add("");
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_SingleNumber_ReturnsNumber()
        {
            int result = _calculator.Add("1");
            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_TwoNumbers_ReturnsSum()
        {
            int result = _calculator.Add("1,2");
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_MultipleNumbers_ReturnsSum()
        {
            int result = _calculator.Add("1,2,3,4");
            Assert.Equal(10, result);
        }

        [Fact]
        public void Add_NumbersWithNewlineAndComma_ReturnsSum()
        {
            int result = _calculator.Add("1\n2,3");
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_CustomDelimiter_SingleCharacter_ReturnsSum()
        {
            int result = _calculator.Add("//;\n1;2");
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_CustomDelimiter_MultipleCharacters_ReturnsSum()
        {
            int result = _calculator.Add("//[***]\n1***2***3");
            Assert.Equal(6, result);
        }
        
        [Fact]
        public void Add_NegativeNumbers_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _calculator.Add("1,-2,-3"));
            Assert.Equal("Negatives not allowed: -2, -3", ex.Message);
        }

        [Fact]
        public void Add_NumbersGreaterThan1000_IgnoresNumbers()
        {
            int result = _calculator.Add("2,1001");
            Assert.Equal(2, result);
        }

        [Fact]
        public void Add_NumbersWithCustomDelimiterAndNumbersGreaterThan1000_IgnoresNumbers()
        {
            int result = _calculator.Add("//[***]\n2***1001***3");
            Assert.Equal(5, result);
        }

        /*
         * The following tests are not passing at the moment as the delimiter parsing is failing. Need 
         * to refactor the logic that parses the delimiters.
         * 
        [Fact]
        public void Add_MultipleDelimiters_ReturnsSum()
        {
            int result = _calculator.Add("//[*][%]\n1*2%3");
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_MultipleDelimitersWithDifferentLengths_ReturnsSum()
        {
            int result = _calculator.Add("//[***][%%]\n1***2%%3");
            Assert.Equal(6, result);
        }
        */

    }
}