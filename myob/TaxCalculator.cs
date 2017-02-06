using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myob
{
    public class TaxCalculator : ITaxCalulator
    {
        private ITaxStrategy _strategy;

        public TaxCalculator(ITaxStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Calculate()
        {
            _strategy.Calculate();
        }

        public void Calculate(ITaxStrategy strategy)
        {
            throw new NotImplementedException();
        }
    }

    public interface ITaxCalulator
    {
        void Calculate(ITaxStrategy strategy);
    }

    public interface ITaxStrategy
    {
        void Calculate();
    }
}
