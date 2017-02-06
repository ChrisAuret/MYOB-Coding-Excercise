using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myob
{
    public class TaxStrategy
    {
        public string Name { get; set; }

        private decimal GetTaxRate(decimal salary)
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

        public decimal Calculate(decimal salary)
        {
            var taxRate = GetTaxRate(salary);
            
            return Math.Round(salary * (1/taxRate), MidpointRounding.AwayFromZero);
        }
    }
}

// Tax Strategy
//0	- $18,200	 Nil
//$18,201	- $37,000	 19c    for	each    $1	over    $18,200
//$37,001	- $80,000	 $3,572	plus    32.5c   for	each    $1	over    $37,000
//$80,001	- $180,000	 $17,547	plus    37c for	each    $1	over    $80,000
//$180,001	and over	 $54,547	plus    45c for	each    $1	over    $180,000
