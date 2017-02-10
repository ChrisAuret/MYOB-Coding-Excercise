using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myob
{
    public class TaxRate
    {
        public TaxRate(double minimum, double maximum, double rate)
        {
            Minimum = minimum;
            Maximum = maximum;
            Rate = rate;
        }

        public double Minimum { get; }
        public double Maximum { get; }
        public double Rate { get; }

        public double CalculateTax(double salary)
        {
            return salary * Rate;
        }
    }
}
