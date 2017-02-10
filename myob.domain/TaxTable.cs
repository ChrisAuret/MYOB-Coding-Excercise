using System.Collections.Generic;
using System.Linq;
using myob.domain.Interfaces;

namespace myob.domain
{
    public class TaxTable : ITaxTable
    {
        private readonly List<TaxBracket> _taxBrackets = new List<TaxBracket>();

        public TaxTable()
        {
            _taxBrackets.Add(new TaxBracket(0, 18200, 0, 0));
            _taxBrackets.Add(new TaxBracket(18201, 37000, 0, 19));
            _taxBrackets.Add(new TaxBracket(37001, 80000, 3572, 32.5M));
            _taxBrackets.Add(new TaxBracket(80001, 180000, 17547, 37));
            _taxBrackets.Add(new TaxBracket(180001, decimal.MaxValue, 54547, 45));
        }

        public TaxBracket GetTaxBracket(decimal salary)
        {
            return _taxBrackets.SingleOrDefault(tr => salary >= tr.Minimum && salary <= tr.Maximum);
        }
    }
}