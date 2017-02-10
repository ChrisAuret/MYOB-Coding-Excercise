namespace myob.domain.Interfaces
{
    public interface IPayCalculator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        decimal CalculateGrossIncome(decimal salary);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salary"></param>
        /// <param name="taxTable"></param>
        /// <returns></returns>
        decimal CalculateIncomeTax(decimal salary, ITaxTable taxTable);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salary"></param>
        /// <param name="taxBracket"></param>
        /// <returns></returns>
        decimal CalculateIncomeTax(decimal salary, TaxBracket taxBracket);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grossIncome"></param>
        /// <param name="incomeTax"></param>
        /// <returns></returns>
        decimal CalculateNetIncome(decimal grossIncome, decimal incomeTax);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grossIncome"></param>
        /// <param name="superRate"></param>
        /// <returns></returns>
        decimal CalculateSuper(decimal grossIncome, decimal superRate);
    }
}