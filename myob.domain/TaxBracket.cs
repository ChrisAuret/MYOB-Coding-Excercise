namespace myob.domain
{
    /// <summary>
    /// Represent a tax bracket object
    /// </summary>
    public class TaxBracket
    {
        public TaxBracket(decimal minimum, decimal maximum, decimal mandatoryTax, decimal rate)
        {
            Minimum = minimum;
            Maximum = maximum;
            MandatoryTax = mandatoryTax;
            Rate = rate;
        }

        /// <summary>
        /// Miximum value for this tax bracket
        /// </summary>
        public decimal Minimum { get; }

        /// <summary>
        /// Miximum value for this tax bracket
        /// </summary>
        public decimal Maximum { get; }

        /// <summary>
        /// The mandatory tax value for this tax bracket
        /// </summary>
        public decimal MandatoryTax { get; }

        /// <summary>
        /// The tax rate for this tax bracket
        /// </summary>
        public decimal Rate { get; }
    }
}