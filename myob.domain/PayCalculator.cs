using System;
using myob.domain.Exceptions;
using myob.domain.Interfaces;

namespace myob.domain
{
    public class PayCalculator : IPayCalculator
    {
        /// <summary>
        /// Calculate monthly Salary
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        public decimal CalculateGrossIncome(decimal salary)
        {
            return Math.Round(
                (salary / 12)
                , 0
                , MidpointRounding.AwayFromZero
            );
        }

        /// <summary>
        /// Calculate income tax for given salary and tax table
        /// </summary>
        /// <param name="salary"></param>
        /// <param name="taxTable"></param>
        /// <returns></returns>
        public decimal CalculateIncomeTax(decimal salary, ITaxTable taxTable)
        {
            var taxBracket = taxTable.GetTaxBracket(salary);

            if (taxBracket == null)
            {
                throw new TaxBracketNotFoundException(salary);
            }

            return Math.Round(
                (taxBracket.MandatoryTax + (salary - taxBracket.Minimum - 1) * (taxBracket.Rate / 100)) / 12
                , 0
                , MidpointRounding.AwayFromZero
            );
        }

        /// <summary>
        /// Calculate income tax for given salary and tax bracket
        /// </summary>
        /// <param name="salary"></param>
        /// <param name="taxBracket"></param>
        /// <returns></returns>
        public decimal CalculateIncomeTax(decimal salary, TaxBracket taxBracket)
        {
            return Math.Round(
                (taxBracket.MandatoryTax + (salary - taxBracket.Minimum - 1) * (taxBracket.Rate / 100)) / 12
                , 0
                , MidpointRounding.AwayFromZero
            );
        }

        /// <summary>
        /// calculate the net income. Gross income - income tax
        /// </summary>
        /// <param name="grossIncome"></param>
        /// <param name="incomeTax"></param>
        /// <returns></returns>
        public decimal CalculateNetIncome(decimal grossIncome, decimal incomeTax)
        {
            return grossIncome - incomeTax;
        }

        /// <summary>
        /// Calculate super from gross income and super %
        /// </summary>
        /// <param name="grossIncome"></param>
        /// <param name="superRate"></param>
        /// <returns></returns>
        public decimal CalculateSuper(decimal grossIncome, decimal superRate)
        {
            return Math.Round(
                grossIncome * (superRate / 100)
                , 0
                , MidpointRounding.AwayFromZero
            );
        }
    }
}