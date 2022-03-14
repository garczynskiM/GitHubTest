using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD;
using TDD.Exceptions;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmptyString()
        {
            string input = "";
            double expected = 0;
            Calculator c = new Calculator();

            double result = c.Calculate(input);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void SingleNumber()
        {
            string input = "432";
            double expected = 432;
            Calculator c = new Calculator();

            double result = c.Calculate(input);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TwoNumbersComma()
        {
            string input = "200,100";
            double expected = 300;
            Calculator c = new Calculator();

            double result = c.Calculate(input);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TwoNumbersNewLine()
        {
            string input = "200\n100";
            double expected = 300;

            Calculator c = new Calculator();

            double result = c.Calculate(input);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ThreeOrMoreNumbersEitherDelimiter()
        {
            string input = "200\n100,300,400\n500";
            double expected = 1500;
            Calculator c = new Calculator();

            double result = c.Calculate(input);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        [ExpectedException(typeof(NegativeNumberException))]
        public void NegativeNumberException()
        {
            string input = "200,300,-400,500";
            Calculator c = new Calculator();

            c.Calculate(input);

            Assert.Fail();
        }
        [TestMethod]
        public void IgnoreHigherThan1000()
        {
            string input = "100\n200,300\n400,500\n1000,1001";
            double expected = 2500;
            Calculator c = new Calculator();

            double result = c.Calculate(input);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void OwnSeparatorAdded()
        {
            string input = "[\n100,200\n300[400";
            double expected = 1000;
            Calculator c = new Calculator();

            double result = c.Calculate(input);

            Assert.AreEqual(expected, result);
        }
    }
}
