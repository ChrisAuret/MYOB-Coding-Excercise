using myob.domain.Interfaces;

namespace myob.domain
{
    /// <summary>
    /// Create a PaySlip for an Employee
    /// </summary>
    public class PayslipGenerator : IPayslipGenerator
    {
        private readonly IPayCalculator _payCalculator;
        private readonly ITaxTable _taxTable;

        public PayslipGenerator(IPayCalculator payCalculator, ITaxTable taxTable)
        {
            _payCalculator = payCalculator;
            _taxTable = taxTable;
        }

        /// <summary>
        /// Combine salary calculations and produce a Payslip for an Employee
        /// </summary>
        /// <param name="employee"></param>
        public string GeneratePayslip(EmployeeDetail employee)
        {
            var employeeName = $"{employee.FirstName} {employee.LastName}";
            var taxBracket = _taxTable.GetTaxBracket(employee.Salary);
            var incomeTax = _payCalculator.CalculateIncomeTax(employee.Salary, taxBracket);
            var grossIncome = _payCalculator.CalculateGrossIncome(employee.Salary);
            var netIncome = _payCalculator.CalculateNetIncome(grossIncome, incomeTax);
            var super = _payCalculator.CalculateSuper(grossIncome, employee.SuperRate);
            var payPeriod = employee.PayPeriod;

            //  Name, payPeriod, grossIncome, incomeTax, netIncome, super
            var payslip = $"{employeeName}, {payPeriod}, {grossIncome}, {incomeTax}, {netIncome}, {super}";

            return payslip;
        }
    }
}