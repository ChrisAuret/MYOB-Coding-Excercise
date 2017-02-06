using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace myob
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new DataLoader();
            var employeeDetails = loader.Load("input.csv");

            var taxCalculator = new TaxCalculator(null);

            var output = new List<EmployeeOutputLine>();

            foreach (var employeeDetail in employeeDetails)
            {
                var grossIncome = employeeDetail.Salary / 12;
                var taxRate = GetTaxRate(employeeDetail.Salary);
                var incomeTax = Math.Round(grossIncome * (1 / taxRate));
                var netIncome = grossIncome - incomeTax;
                var super = grossIncome * ( 1/ employeeDetail.SuperRate);

                var employeeOutput = new EmployeeOutputLine
                {
                    FirstName = employeeDetail.FirstName,
                    LastName = employeeDetail.LastName,
                    GrossIncome = grossIncome,
                    IncomeTax = incomeTax,
                    NetIncome = netIncome,
                    Super = super
                };

                output.Add(employeeOutput);

            }

            foreach (var eol in output)
            {
                //Output	(name,	pay	period,	gross	income,	income	tax,	net	income,	super):
                Console.WriteLine("{0} {1}, {2}, {3}, {4}, {5}", eol.FirstName, eol.LastName, eol.GrossIncome, eol.IncomeTax, eol.NetIncome, eol.Super);
            }
        }

        public static decimal GetTaxRate(decimal salary)
        {
            decimal taxRate = 1;

            if (salary <= 18200)
            {
                taxRate = 1;
            }
            else if (salary >= 18201 && salary <= 37000)
            {
                taxRate = 19;
            }
            else if (salary >= 37001 && salary <= 80000)
            {
                taxRate = 32.5m;
            }
            else if (salary > 80001 && salary <= 180000)
            {
                taxRate = 37;
            }
            else if (salary >= 180001)
            {
                taxRate = 45;
            }

            return taxRate;
        }
    }
}

public class EmployeeOutputLine
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PayPeriod { get; set; }
    public decimal GrossIncome { get; set; }
    public decimal IncomeTax { get; set; }
    public decimal NetIncome { get; set; }
    public decimal Super { get; set; }
}

// INPUT:
//  first name
//  last name
//  annual salary(positive integer)
//  super rate(0% - 50%	inclusive)
//  payment start date

// Assumptions each csv file has 10 000 payslips

// EmployeeDetails
// Payslip
// PayslipGenerator
// calculate


//No proper Automated Unit Tests written
//A sense of reusability is missing
//Usability / End user experience is not good
//No proper documentation around how to use / read the code
//Design and logical skills doesn’t sound to be up to date.Hence the code is not reusable and very hard to refactor.
//Lot of redundancy around unit testing
//The entire application was written in a single text file and expected us to know things by reading through.Assumptions, instructions on how to run the application were not provided. The coding exercise asked for it.
//We were expecting more test.
//There were a few things in the code which we noticed such as use of CSV serializer / deserializer.. this indicates over-engineering
//UI did not feel user friendly.
//No instructions on how to run the application.
//No real focus on testing the code.
//Inconsistency in the coding style
//The test provided were more integration test then unit test.A lot of interfaces are used, however, no mocked tests can be seen for them.
//Domain model class also mixed with business logic, for example in SalarySlip.cs Also we see that the candidate has written the business logic inside the Data Access layer and that is very much possible with so much unwanted generated code.The objective is to solve a easy problem and we don’t see a need to make it complex. 