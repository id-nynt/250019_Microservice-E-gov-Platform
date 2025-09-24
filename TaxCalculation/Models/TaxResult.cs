namespace TaxCalculation.Models
{
    public class TaxResult
    {
        public decimal Income { get; set; }
        public decimal Tax { get; set; }
        public decimal EffectiveRate { get; set; }
    }
}
