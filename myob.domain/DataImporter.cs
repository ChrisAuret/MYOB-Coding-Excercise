using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using myob.domain.Interfaces;

namespace myob.domain
{
    public class DataImporter : IDataImporter
    {
        /// <summary>
        /// Import records from CSV file
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public List<EmployeeDetail> Import(string filepath)
        {
            var employees = new List<EmployeeDetail>();
            var failures = new List<string>();

            using (var fs = File.OpenRead(filepath))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(',');

                    try
                    {
                        var employeeDetail = new EmployeeDetail
                        {
                            FirstName = values[0],
                            LastName = values[1],
                            Salary = Convert.ToDecimal(values[2]),
                            SuperRate = Convert.ToDecimal(Regex.Replace(values[3], @"[^0-9]+", "")),
                            PayPeriod = values[4],
                        };

                        employees.Add(employeeDetail);
                    }
                    catch (Exception ex)
                    {
                        failures.Add(line + " | ERROR: " + ex.Message);
                    }
                }
            }

            if (failures.Any())
            {
                File.WriteAllLines("failures.csv", failures);
            }

            return employees;
        }
    }
}