namespace FinancialTrackerApi.Models.DTOs
{
    /// <summary>
    /// Income DTO
    /// </summary>
    public class IncomeDTO
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
        /// amount
        /// </summary>
        public float Amount { get; set; }
        /// <summary>
        /// date added
        /// </summary>
        public DateTime Date { get; set; }
    }
}
