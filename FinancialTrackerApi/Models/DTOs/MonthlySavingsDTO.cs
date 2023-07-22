namespace FinancialTrackerApi.Models.DTOs
{
    /// <summary>
    /// Monthly Savings DTO
    /// </summary>
    public class MonthlySavingsDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// month
        /// </summary>
        public string Month { get; set; }
        /// <summary>
        /// year
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// liquid savings
        /// </summary>
        public float LiquidSavings { get; set; }
        /// <summary>
        /// total savings
        /// </summary>
        public float TotalSavings { get; set; }
    }
}
