using System;
using myob.domain.Interfaces;

namespace myob
{
    public class Application : IApplication
    {
        private readonly IDataImporter _dataImporter;
        private readonly IPayslipGenerator _payslipGenerator;

        public Application(IDataImporter dataImporter, IPayslipGenerator payslipGenerator)
        {
            _dataImporter = dataImporter;
            _payslipGenerator = payslipGenerator;
        }

        public void Run()
        {
            var employeeDetails = _dataImporter.Import("input.csv");

            foreach (var employeeDetail in employeeDetails)
            {
                var payslip = _payslipGenerator.GeneratePayslip(employeeDetail);

                Console.WriteLine(payslip);
            }
        }
    }
}