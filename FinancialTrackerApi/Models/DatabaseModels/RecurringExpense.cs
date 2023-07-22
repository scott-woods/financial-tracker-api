namespace FinancialTrackerApi.Models.DatabaseModels
{
    /// <summary>
    /// Recurring expense
    /// </summary>
    public class RecurringExpense
    {
        /// <summary>
        /// Recurring expense id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Foreign key to user
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Expense name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Amount
        /// </summary>
        public float Amount { get; set; }
        /// <summary>
        /// Timeframe (monthly, yearly)
        /// </summary>
        public Timeframe Timeframe { get; set; }
        /// <summary>
        /// Date expense stops
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
