namespace myob.domain.Interfaces
{
    public interface IPayslipGenerator
    {
        /// <summary>
        /// Combine salary calculations and produce a Payslip for a Employee
        /// </summary>
        /// <param name="employee"></param>
        string GeneratePayslip(EmployeeDetail employee);
    }
}