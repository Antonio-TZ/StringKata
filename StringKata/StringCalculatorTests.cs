using System;
using NUnit.Framework;

namespace StringKata {
    [TestFixture]
    public class StringCalculatorTests {

        private StringCalculator calculator = new StringCalculator();

        [Test]
        public void return_0_when_passed_an_empty_string() {
            Assert.AreEqual(0, calculator.add(""));
        }

        [Test]
        public void return_number_passed() {
            Assert.AreEqual(1, calculator.add("1"));
        }

        [Test]
        public void return_sum_of_2_numbers() {
            Assert.AreEqual(3, calculator.add("1,2"));
        }

        [Test]
        [TestCase("1,2,3", ExpectedResult = 6)]
        [TestCase("1,2,3,4", ExpectedResult = 10)]
        [TestCase("1,2,3,4,5", ExpectedResult = 15)]
        public int return_sum_of_multiple_numbers(string input) {
            return calculator.add(input);
        }

        [Test]
        public void return_sum_of_multiple_numbers_with_newline_delimiter() {
            Assert.AreEqual(6, calculator.add("1,2\n3"));
        }

        [Test]
        public void return_sum_of_multiple_numbers_with_custom_delimiter() {
            Assert.AreEqual(10, calculator.add("//;\n1,2\n3;4"));
        }

        [Test]
        public void return_sum_of_multiple_numbers_with_customlength_delimiter() {
            Assert.AreEqual(10, calculator.add("//[*-*]\n1,2\n3*-*4"));
        }

        [Test]
        public void return_sum_of_multiple_numbers_with_multiple_customlength_delimiter() {
            Assert.AreEqual(21, calculator.add("//[*-*][!@][$]\n1,2\n3*-*4!@5$6"));
        }

        [Test]
        public void throw_exception_when_receiving_negatives() {
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.add("1,2,-4"));
        }

        [Test]
        public void ignore_numbers_greaterthan_1000() {
            Assert.AreEqual(10, calculator.add("//;\n1,2\n3;4,1002"));
        }
    }
}
