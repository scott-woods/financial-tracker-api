namespace FinancialTrackerApi.Models.DatabaseModels
{
    /// <summary>
    /// piecemeal income
    /// </summary>
    public class Income
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// user id fk
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// name (optional)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// amount
        /// </summary>
        public float Amount { get; set; }
        /// <summary>
        /// date added
        /// </summary>
        public DateTime Date { get; set; }
    }
}
