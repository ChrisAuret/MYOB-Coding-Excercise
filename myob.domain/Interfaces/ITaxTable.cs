namespace myob.domain.Interfaces
{
    public interface ITaxTable
    {
        TaxBracket GetTaxBracket(decimal salary);
    }
}