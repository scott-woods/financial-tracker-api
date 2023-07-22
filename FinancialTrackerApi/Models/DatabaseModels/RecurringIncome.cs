namespace FinancialTrackerApi.Models.DatabaseModels
{
    /// <summary>
    /// Recurring income
    /// </summary>
    public class RecurringIncome
    {
        /// <summary>
        /// recurring income id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User id fk
        /// </summary>
        public virtual User User { get; set; }
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
