namespace FinancialTrackerApi.Models.DTOs
{
    /// <summary>
    /// Recurring Income DTO
    /// </summary>
    public class RecurringIncomeDTO
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
        /// Timeframe
        /// </summary>
        public Timeframe Timeframe { get; set; }
    }
}
