namespace FinancialTrackerApi.Models.DatabaseModels
{
    /// <summary>
    /// piecemeal expense
    /// </summary>
    public class Expense
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
