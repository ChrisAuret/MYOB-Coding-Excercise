using System.Linq;
using myob.domain;
using myob.domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace myob.tests
{
    [TestFixture]
    public class PayslipGeneratorTests
    {
        private EmployeeDetail _employee;

        [OneTimeSetUp]
        public void Setup()
        {
            _employee = new EmployeeDetail
            {
                Salary = 120000,
                FirstName = "John",
                LastName = "Smith",
                PayPeriod = "01 March - 31 March",
                SuperRate = 9
            };
        }

        [Test]
        public void GeneratePayslip_should_make_correct_calls_to_service_methods()
        {
            // Arrange
            var payCalculator = new Mock<IPayCalculator>();
            payCalculator.Setup(x => x.CalculateIncomeTax(It.IsAny<decimal>(), It.IsAny<ITaxTable>())).Verifiable();
            payCalculator.Setup(x => x.CalculateGrossIncome(It.IsAny<decimal>())).Verifiable();
            payCalculator.Setup(x => x.CalculateNetIncome(It.IsAny<decimal>(), It.IsAny<decimal>())).Verifiable();
            payCalculator.Setup(x => x.CalculateSuper(It.IsAny<decimal>(), It.IsAny<decimal>())).Verifiable();

            var taxTable = new Mock<ITaxTable>();
            taxTable.Setup(x => x.GetTaxBracket(It.IsAny<decimal>())).Returns(new TaxBracket(0, 18000, 0, 0));

            var payslipGenerator = new PayslipGenerator(payCalculator.Object, taxTable.Object);

            // Act
            payslipGenerator.GeneratePayslip(_employee);

            // Assert
            payCalculator.Verify(
                 x => x.CalculateGrossIncome(It.IsAny<decimal>()),
                 Times.Once()
             );

            payCalculator.Verify(
                x => x.CalculateNetIncome(It.IsAny<decimal>(), It.IsAny<decimal>()),
                Times.Once()
            );

            payCalculator.Verify(
                x => x.CalculateSuper(It.IsAny<decimal>(), It.IsAny<decimal>()),
                Times.Once()
            );
        }

        [Test]
        public void GeneratePayslip_creates_valid_payslip()
        {
            // Arrange
            var payCalculator = new PayCalculator();
            var taxTable = new TaxTable();

            // Act
            var payslipGenerator = new PayslipGenerator(payCalculator, taxTable);
            var payslip = payslipGenerator.GeneratePayslip(_employee)
                .Split(',')
                .Select(x => x.Trim())
                .ToArray();

            // Name
            Assert.AreEqual(payslip[0], "John Smith");

            // Pay period
            Assert.AreEqual(payslip[1].Trim(), "01 March - 31 March");

            // Gross income
            Assert.AreEqual(payslip[2], "10000");

            // Income tax
            Assert.AreEqual(payslip[3], "2696");

            // Net income
            Assert.AreEqual(payslip[4], "7304");

            // Super
            Assert.AreEqual(payslip[5], "900");
        }
    }
}