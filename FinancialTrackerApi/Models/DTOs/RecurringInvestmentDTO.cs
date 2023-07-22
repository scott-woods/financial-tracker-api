namespace FinancialTrackerApi.Models.DTOs
{
    /// <summary>
    /// Recurring Investment DTO
    /// </summary>
    public class RecurringInvestmentDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// amount
        /// </summary>
        public float Amount { get; set; }
        /// <summary>
        /// timeframe (monthly, yearly)
        /// </summary>
        public Timeframe Timeframe { get; set; }
        /// <summary>
        /// true if this should be subtracted from income
        /// </summary>
        public bool IsFromLiquid { get; set; }
    }
}
