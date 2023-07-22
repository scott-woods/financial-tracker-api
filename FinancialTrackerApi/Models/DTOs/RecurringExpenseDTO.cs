namespace FinancialTrackerApi.Models.DTOs
{
    /// <summary>
    /// Recurring Expense DTO
    /// </summary>
    public class RecurringExpenseDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
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
