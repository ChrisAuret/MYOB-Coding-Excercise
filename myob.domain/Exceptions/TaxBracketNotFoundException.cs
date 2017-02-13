using System;

namespace myob.domain.Exceptions
{
    public class TaxBracketNotFoundException : Exception
    {
        public TaxBracketNotFoundException(decimal salary)
        {
            Message = $"Tax bracket not found for given salary - '{salary}'";
        }

        public override string Message { get; }
    }
}