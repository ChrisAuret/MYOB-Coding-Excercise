using myob.domain;
using NUnit.Framework;

namespace myob.tests
{
    [TestFixture]
    public class PayCalculatorTests
    {
        private PayCalculator _payCalculator;

        [OneTimeSetUp]
        public void Setup()
        {
            _payCalculator = new PayCalculator();
        }

        [Test]
        [TestCase(10000, 833)]  // Down
        [TestCase(12000, 1000)]
        [TestCase(36000, 3000)]
        [TestCase(50000, 4167)] // Up
        public void CalculateGrossIncome_should_return_correct_amount(decimal input, decimal expected)
        {
            // Act
            var output = _payCalculator.CalculateGrossIncome(input);

            // Assert
            Assert.AreEqual(expected, output);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(18000, 0)]
        [TestCase(60050, 922)]
        public void CalculateIncomeTax_should_return_correct_amount(decimal salary, decimal expected)
        {
            // Arrange
            var taxTable = new TaxTable();
            var taxBracket = taxTable.GetTaxBracket(salary);
            
            // Act
            var actual = _payCalculator.CalculateIncomeTax(salary, taxBracket);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(60050, 922, 59128)]
        public void CalculateNetIncome_should_return_correct_amount(decimal grossSalary, decimal incomeTax, decimal expected)
        {
            // Act
            var actual = _payCalculator.CalculateNetIncome(grossSalary, incomeTax);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(5000, 9, 450)]
        [TestCase(5000, 10, 500)]
        [TestCase(5002, 11, 550)] // Round Down
        [TestCase(5005, 11, 551)] // Round Up
        [TestCase(550, 11, 61)]   // Round Up
        public void CalculateSuper_should_return_correct_amount(decimal grossIncome, decimal rate, decimal expected)
        {
            // Act
            var actual = _payCalculator.CalculateSuper(grossIncome, rate);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}