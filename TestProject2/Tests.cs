using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestProject2
{
    [TestFixture]
    public class Tests
    {
        private Calculator _calculator = new Calculator();

        [Test]
        public void CalculatorTest1()
        {
            ResultShouldBe(3, 1, 2);
        }

        private void ResultShouldBe(int expected, int first, int second)
        {
            Assert.AreEqual(expected, _calculator.Add(first, second));
        }

        [TestCase(1, 2, 3)]
        [TestCase(-1, -2, -3)]
        public void CalculatorTest2(int number1, int number2, int expected)
        {
            var calculator = new Calculator();

            var actual = calculator.Add(number1, number2);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(TestCase), nameof(TestCase.AddTestCases))]
        public void CalculatorTest3(int number1, int number2, int expected)
        {
            var calculator = new Calculator();

            var actual = calculator.Add(number1, number2);

            Assert.AreEqual(expected, actual);
        }

        internal class TestCase
        {
            public static IEnumerable<TestCaseData> AddTestCases
            {
                get
                {
                    yield return new TestCaseData(1, 2, 3).SetName("1 + 2 = 3");
                    yield return new TestCaseData(-4, 3, -1).SetName("-4 + 3 = -1");
                }
            }
        }
    }
}