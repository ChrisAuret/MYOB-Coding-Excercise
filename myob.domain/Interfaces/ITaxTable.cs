namespace myob.domain.Interfaces
{
    public interface ITaxTable
    {
        /// <summary>
        /// Get the relevant tax bracket for the given salary
        /// </summary>
        /// <param name="salary"></param>
        /// <returns>TaxBracket</returns>
        TaxBracket GetTaxBracket(decimal salary);
    }
}