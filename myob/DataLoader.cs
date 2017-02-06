﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace myob
{
    public class DataLoader :IDataLoader
    {
        public List<EmployeeDetail> Load(string filepath)
        {
            using (var fs = File.OpenRead(filepath))
            using (var reader = new StreamReader(fs))
            {
                var employees = new List<EmployeeDetail>();
                var failures = new List<EmployeeDetail>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var values = line.Split(',');

                    //var super = String(input.Where(Char.IsDigit).ToArray());
                    try
                    {
                        var employeeDetail = new EmployeeDetail
                        {
                            FirstName = values[0],
                            LastName = values[1],
                            Salary = Convert.ToDecimal(values[2]),
                            SuperRate = Convert.ToDecimal(Regex.Replace(values[3], @"[^0-9]+", "")),
                            StartDate = values[4],
                        };

                        employees.Add(employeeDetail);
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }

                return employees;
            }
        }
    }

    public interface IDataLoader
    {
        List<EmployeeDetail> Load(string filepath);
    }
}
