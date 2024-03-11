using Moq;
using StringCalcKata;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization =true)]
namespace StringCalcTests
{
    [Collection("firstRound")]
    public class UnitTest1
    {
        [Fact]
        public void NumbersEntered_AcceptsNumandZero()
        {
            string[] numbers = { "9", "0" };
            int expectedResult = 9;
            int results = Calculator.Calc(numbers);
            Assert.Equal(expectedResult, results);

        }
    }

    public class UnitTest2
    {
        [Fact]
        public void NumbersEntered_AcceptsNums()
        {
            string[] numbers = { "10", "20" };
            int expectedResult = 30;
            int results = Calculator.Calc(numbers);
            Assert.Equal(expectedResult, results);
        }
    }

    public class UnitTest3
    {
        [Fact]
        public void NumbersEntered_AcceptsEmpyStrings()
        {
            string[] numbers = { "", "" };
            int expectedResult = 0;
            int results = Calculator.Calc(numbers);
            Assert.Equal(expectedResult, results);
        }
    }

    public class UnitTest4
    {
        [Fact]
        public void NumbersEntered_AcceptsSingleEmptyString()
        {
            string[] numbers = { "4", "" };
            int expectedResult = 4;
            int results = Calculator.Calc(numbers);
            Assert.Equal(expectedResult, results);
        }
    }


    public class UnitTest5
    {
        [Fact]
        public void NumbersEntered_AcceptsNewLine()
        {
            string input = "1\\n2,3";
            using (var stringReader = new StringReader(input))
            {
                Console.SetIn(stringReader);
                string[] inputNumbers = Prompt.NumbersEntered(out _);
                int calculation = Calculator.Calc(inputNumbers);
                Assert.Equal(6, calculation);
            }
        }
    }

    public class UnitTest6
    {
        [Fact]
        public void NumbersEntered_CheckandReturnsNegs()
        {
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            string input = "1,-2,3";
            Console.SetIn(new StringReader(input));
            Prompt.NumbersEntered(out string values);
            Assert.Contains("Cannot enter negative numbers", consoleOutput.ToString());
        }
    }

    [Collection("secondRound")]
    public class UnitTest7
    {
        [Fact]
        public void NumbersEntered_AcceptsNewDelimiter()
        {
            string input = "//;\\n1;2";
            using (var stringReader = new StringReader(input))
            {
                Console.SetIn(stringReader);
                string[] inputNumbers = Prompt.NumbersEntered(out _);
                int calculation = Calculator.Calc(inputNumbers);
                Assert.Equal(3, calculation);
            }
        }
    }
}
