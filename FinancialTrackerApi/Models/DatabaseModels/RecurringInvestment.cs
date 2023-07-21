namespace FinancialTrackerApi.Models.DatabaseModels
{
    /// <summary>
    /// Recurring investment db model
    /// </summary>
    public class RecurringInvestment
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// user id fk
        /// </summary>
        public User User { get; set; }
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
