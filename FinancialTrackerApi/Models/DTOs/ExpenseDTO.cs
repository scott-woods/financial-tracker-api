namespace FinancialTrackerApi.Models.DTOs
{
    /// <summary>
    /// Expense DTO
    /// </summary>
    public class ExpenseDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// name (optional)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Amount
        /// </summary>
        public float Amount { get; set; }
        /// <summary>
        /// date added
        /// </summary>
        public DateTime Date { get; set; }
    }
}
