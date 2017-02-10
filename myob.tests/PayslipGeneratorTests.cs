using myob.domain;
using myob.domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace myob.tests
{
    [TestFixture]
    public class PayslipGeneratorTests
    {
        private PayCalculator _payCalculator;
        private EmployeeDetail _employee;
        private ITaxTable _taxTable;

        [OneTimeSetUp]
        public void Setup()
        {
            _payCalculator = new PayCalculator();

            _employee = new EmployeeDetail
            {
                Salary = 120000,
                FirstName = "John",
                LastName = "Smith",
                PayPeriod = "01 March",
                SuperRate = 9
            };

            _taxTable = new TaxTable();
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

        public void GeneratePayslip_creates_valid_payslip()
        {
            var payCalculator = new Mock<IPayCalculator>();
            payCalculator.Setup(x => x.CalculateIncomeTax(It.IsAny<decimal>(), It.IsAny<ITaxTable>()));
            payCalculator.Setup(x => x.CalculateGrossIncome(It.IsAny<decimal>()));
            payCalculator.Setup(x => x.CalculateNetIncome(It.IsAny<decimal>(), It.IsAny<decimal>()));
            payCalculator.Setup(x => x.CalculateSuper(It.IsAny<decimal>(), It.IsAny<decimal>()));

            var taxTable = new Mock<ITaxTable>();
            taxTable.Setup(x => x.GetTaxBracket(It.IsAny<decimal>()))
                .Returns(new TaxTable().GetTaxBracket(_employee.Salary));

            var payslipGenerator = new PayslipGenerator(payCalculator.Object, taxTable.Object);
        }
    }
}
