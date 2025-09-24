namespace TaxCalculation.Models
{
    public class TaxBracket
    {
        public decimal Min { get; set; }
        public decimal? Max { get; set; }
        public decimal Rate { get; set; }
        public decimal BaseTax { get; set; }
    }
}
